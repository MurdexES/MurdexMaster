using MailKit;
using MailKit.Net.Imap;
using Microsoft.Win32;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace IMAP_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MailMessage Message { get; set; }
        public ImapClient Client { get; set; } = new ImapClient();
        public ObservableCollection<MimeMessage> Messages { get; set; } = new ObservableCollection<MimeMessage>();
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ReciverEmail { get; set; } = string.Empty;
        public MailAddress UserAddress { get; set; }
        public MailAddress ReciverAddress { get; set; }
        public bool isAttached = false;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            SmtpClient smtpClient = new("smtp.gmail.com", 587);

            if (!isAttached)
            {
                try
                {
                    ReciverEmail = ReceiverTB.Text.ToString();

                    ReciverAddress = new(ReciverEmail);
                    Message = new(UserAddress, ReciverAddress);

                    Message.IsBodyHtml = true;
                    Message.Subject = SubjectTB.Text;
                    Message.Body = MailBody.Text;
                    isAttached = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }

            }

            try
            {
                smtpClient.Credentials = new NetworkCredential(Email, Password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(Message);

                MessageBox.Show("Your Mail Have Been Sent");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void AttachBtn_Click(object sender, RoutedEventArgs e)
        {
            ReciverEmail = ReceiverTB.Text.ToString();

            ReciverAddress = new(ReciverEmail);
            Message = new(UserAddress, ReciverAddress);
            
            Message.IsBodyHtml = true;
            Message.Subject = SubjectTB.Text;
            Message.Body = MailBody.Text;
            
            isAttached = true;

            OpenFileDialog openFileDialog = new();
            openFileDialog.ShowDialog();
            Message.Attachments.Add(new Attachment(openFileDialog.FileName));
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            Email = EmailTB.Text.ToString();
            Password = PasswordTB.Text.ToString();

            UserAddress = new(Email);
        }

        private void AllMessagesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserAddress != null)
            {
                Client.Connect("imap.gmail.com", 993, true);
                Client.Authenticate(Email, Password);
                Client.Inbox.Open(FolderAccess.ReadOnly);

                for (int i = 0; i < 15; i++)
                {
                    Messages.Add(Client.Inbox.GetMessage(i));
                }

                Client.Disconnect(true);
                Client.Dispose();
            }
            else
            {
                MessageBox.Show("You have to connect");
            }
        }
    }
}
