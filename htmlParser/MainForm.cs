using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace htmlParser
{
    public partial class MainForm : Form
    {
        HashSet<string> newLinksSearched = new HashSet<string>();
        private const string PlaceholderText = "For example: https://wingram.org";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            urlTextBox.Text = PlaceholderText;
            urlTextBox.ForeColor = Color.Gray;
            parseButton.Select();
        }

        private async void parseButton_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text.Trim().Trim('"');

            if (string.IsNullOrEmpty(url) || url == PlaceholderText)
            {
                MessageBox.Show("Пожалуйста, введите корректный URL.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
                urlTextBox.Text = url;
            }

            parseButton.Enabled = false;
            htmlOutputBox.Text = "Page loading...";
            newLinksSearched.Clear();
            string normalizedStartUrl = new Uri(url).GetLeftPart(UriPartial.Query);
            newLinksSearched.Add(normalizedStartUrl);

            try
            {
                await ParserAsync(url);
            }




            finally
            {
                parseButton.Enabled = true;
            }
        }

        public async Task<ISet<string>> GetNewLinks(string content, Uri currentPageUri)
        {
            try
            {
                Queue<string> newLinksQueue = new Queue<string>();
                HashSet<string> savedToFile = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                Regex regexLink = new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");

                string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string folderPath = Path.Combine(docs, "ParsedLinks");

                Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, "sites.txt");

                ISet<string> newLinks = new HashSet<string>();

                if (File.Exists(filePath))
                {
                    foreach (var previousLinks in File.ReadAllLines(filePath, Encoding.UTF8))
                    {
                        savedToFile.Add(previousLinks.Trim());
                    }
                }
                foreach (var match in regexLink.Matches(content))
                {
                    if (newLinks.Add(match.ToString()))
                    {
                        newLinksQueue.Enqueue(match.ToString());
                    }
                }

                string rawRoot = urlTextBox.Text.Trim();

                if (!rawRoot.EndsWith("/")) rawRoot += "/";
                Uri.TryCreate(rawRoot, UriKind.Absolute, out Uri rootUri);

                while (newLinksQueue.Count > 0)
                {
                    string currentLink = newLinksQueue.Dequeue();
                    if (!Uri.TryCreate(currentPageUri, currentLink, out Uri validLink) || (validLink.Scheme != Uri.UriSchemeHttp && validLink.Scheme != Uri.UriSchemeHttps))
                    {
                        continue;
                    }
                    if (rootUri != null && validLink.Host != rootUri.Host)
                    {
                        continue;
                    }
                    string URL = validLink.GetLeftPart(UriPartial.Query);
                    if (!newLinksSearched.Add(URL))
                    {
                        continue;
                    }
                    if (savedToFile.Add(URL))
                    {
                        File.AppendAllText(filePath, URL + Environment.NewLine, Encoding.UTF8);
                    }
                    try
                    {
                        await ParserAsync(URL);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось спарсить {URL}: {ex.Message}");
                    }
                }

                return newLinks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return newLinksSearched;
            }
        }

        private async Task<ISet<string>> ParserAsync(string url)
        {
            ISet<string> foundLinks = new HashSet<string>();
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
            string jsonPath = "useragent.json";
            if (File.Exists(jsonPath))
            {
                string jsonString = File.ReadAllText(jsonPath);
                var data = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
                var desktopList = data["Desktop"];
                var datas = new Queue<string>(desktopList);
                HashSet<string> links = new HashSet<string>();
                HashSet<string> searched = new HashSet<string>(desktopList);
                if (datas.Count > 0)
                {
                    string current = datas.Dequeue();
                    myHttpWebRequest.UserAgent = current;
                    datas.Enqueue(current);
                    if (searched.Add(current))
                    {
                        System.Console.WriteLine($"Added unique json file =========>>>{current}");

                    }
                }
            }

            try
            {
                using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)await myHttpWebRequest.GetResponseAsync())
                using (var stream = myHttpWebResponse.GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string html = await reader.ReadToEndAsync();
                    LoadAndShowHtml(html, url);
                    string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folderPath = Path.Combine(docs, "ParsedLinks");
                    Directory.CreateDirectory(folderPath);

                    string safeFileName = Regex.Replace(url, @"[^a-zA-Z0-9_-]", "_") + ".txt";
                    string fullContent = $"=== URL: {url} ==={Environment.NewLine}{html}";
                    File.WriteAllText(Path.Combine(folderPath, safeFileName), fullContent, Encoding.UTF8);
                    foundLinks = await GetNewLinks(html, new Uri(url));
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            } 
            return foundLinks;
        }
            


        private void LoadAndShowHtml(string html, string url)
        {
            htmlOutputBox.AppendText(
            $"================ {url} ================{Environment.NewLine}" + html + $"{Environment.NewLine}{Environment.NewLine}");
        }


        private void urlTextBox_Enter(object sender, EventArgs e)
        {
            if (urlTextBox.Text == PlaceholderText)
            {
                urlTextBox.Text = string.Empty;
                urlTextBox.ForeColor = Color.White;
            }
        }

        private void urlTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(urlTextBox.Text))
            {
                urlTextBox.Text = PlaceholderText;
                urlTextBox.ForeColor = Color.Gray;
            }
        }

        private void htmlOutputBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void outputContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
