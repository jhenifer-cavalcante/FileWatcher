using FileWatcher.Properties;
using System;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Sockets;

namespace FileWatcher
{
    public partial class MainWindow : Window
    {
        FileSystemWatcher watcher;
        private static readonly HttpClient client = new HttpClient();
        private Timer timer = new Timer();
        private bool isWatching;
        static string myIP = string.Empty;
        static string hostName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(Settings.Default.PathSetting))
            {
                txtDirectory.Text = Settings.Default.PathSetting;//Get Saved Path  
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDirectory.Text = dialog.SelectedPath;
            }
        }

        private void btnListen_Click(object sender, RoutedEventArgs e)
        {
            //We want to check whether the filewatcher is on or not and display usefull signal to the user either to start or stop  
            if (isWatching)
            {
                btnListen.Content = "Monitorar";
                stopWatching();
            }
            else
            {
                btnListen.Content = "Interromper";
                startWatching();
            }

        }

        private void startWatching()
        {
            if (!isDirectoryValid(txtDirectory.Text))
            {
                AppendListViewcalls(DateTime.Now + " - Diretório Inválido");
                return;
            }
            isWatching = true;
            timer.Enabled = true;
            timer.Start();
            timer.Interval = 500;
            AppendListViewcalls(DateTime.Now + " - Monitorando...");

            watcher = new FileSystemWatcher();
            watcher.Path = txtDirectory.Text;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
            watcher.Filter = "*.*";
            watcher.Renamed += new RenamedEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
            GettingIP();
        }

        private void stopWatching()
        {
            isWatching = false;
            timer.Enabled = false;
            timer.Stop();
            AppendListViewcalls(DateTime.Now + " - Processo intemrrompido");
        }

        private bool isDirectoryValid(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void OnChanged(object source, FileSystemEventArgs e)
        {
            //filter file types  
            if (Regex.IsMatch(System.IO.Path.GetExtension(e.Name), @"\.pdf", RegexOptions.IgnoreCase))
            {
                if (e.ChangeType == WatcherChangeTypes.Renamed)
                    {
                        AppendListViewcalls("Arquivo: \"" + e.Name + "\"- " + DateTime.Now + " " + "Criado " + "em " + myIP);
                        WebRequester(e.Name , "true");
                    }
                else
                    {
                        AppendListViewcalls("Arquivo: \"" + e.Name + "\"- " + DateTime.Now + " " + e.ChangeType + " " + "on " + myIP);
                        WebRequester(e.Name, "false");
                    }
            }

            else
                AppendListViewcalls("Arquivo: \"" + e.Name + "\" Foi ignorado");
        }

        public void AppendListViewcalls(string input)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate ()
            {
                this.lstResults.Items.Add(input);

            }));

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Salva o caminho ao fechar
            Settings.Default.PathSetting = txtDirectory.Text;
            Settings.Default.Save();
        }

        static void GettingIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = ip.ToString();
                }
            }
            hostName = Dns.GetHostName();
        }

        private async void WebRequester(string filename, string stts)
        {
            var values = new Dictionary<string, string>
                {
                    { "file", filename },
                    { "status", stts },
                    { "maq", myIP },
                    { "host", hostName }
                };
            try
            {
                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("http://uploadcontratos.ddns.net:5000/monitorar", content);
                response.EnsureSuccessStatusCode();

                string responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
            catch
            {
                AppendListViewcalls("Algo deu errado");
            }
        }
    }
}
