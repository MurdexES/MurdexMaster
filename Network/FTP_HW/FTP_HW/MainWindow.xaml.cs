using FluentFTP;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace FTP_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AsyncFtpClient? client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            Progress<FtpProgress> progress = new Progress<FtpProgress>(x => {

                if (x.Progress < 0)
                {
                    DownloadProgressBar.IsIndeterminate = true;
                }
                else
                {
                    DownloadProgressBar.Value = Convert.ToInt32(x.Progress);
                    PercentTextBlock.Text = Convert.ToInt32(x.Progress) + "%";
                }
            });

            if(FilesListBox.SelectedIndex >= 0)
            {
                string fileName = FilesListBox.SelectedItem.ToString();

                await client.DownloadFile(fileName, fileName, FtpLocalExists.Overwrite, FtpVerify.None, progress);

                MessageBox.Show("Downloaded Successfully");
            }
            else
            {
                MessageBox.Show("No selected file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var diolog = new OpenFileDialog();
            diolog.Filter = "All files (*.*)|*.*";
            diolog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (diolog.ShowDialog() == true)
            {
                string selectedFilePath = diolog.FileName;
                string fileName = Path.GetFileName(selectedFilePath);

                FileTextBox.Text = selectedFilePath;

                Progress<FtpProgress> progress = new Progress<FtpProgress>(x =>
                {
                    if (x.Progress < 0)
                    {
                        DownloadProgressBar.IsIndeterminate = true;
                    }
                    else
                    {
                        DownloadProgressBar.Value = Convert.ToInt32(x.Progress);
                        PercentTextBlock.Text = Convert.ToInt32(x.Progress) + "%";
                    }
                });

                FilesListBox.Items.Add(fileName);

                await client.UploadFile(selectedFilePath, fileName, FtpRemoteExists.Overwrite, false, FtpVerify.None, progress);

                MessageBox.Show("Upload Successfully");
            }
        }
     

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ServerTextBox.Text != string.Empty && UsernameTextBox.Text != string.Empty && PasswordTextBox.Text != string.Empty)
                {
                    client = new AsyncFtpClient(ServerTextBox.Text.ToString(), UsernameTextBox.Text.ToString(), PasswordTextBox.Text.ToString());
                    await client.Connect();

                    MessageBox.Show("Connected Successfully");

                    DownloadButton.IsEnabled = true;
                    UploadButton.IsEnabled = true;

                    ConnectButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Error no valid info", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
