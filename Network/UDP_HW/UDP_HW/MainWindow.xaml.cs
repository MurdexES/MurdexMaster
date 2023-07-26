using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace UDP_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UdpClient udpClient = new UdpClient();
        private int port;
        private IPAddress address;

        public MainWindow()
        {
            InitializeComponent();

            address = IPAddress.Parse("224.1.2.3");
            port = 8080;

            udpClient.JoinMulticastGroup(address);
            udpClient.EnableBroadcast = true;
            
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));
            udpClient.BeginReceive(Receive, null);
        }

        private void Receive(IAsyncResult asyncRes)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

                byte[] data = udpClient.EndReceive(asyncRes, ref endPoint);
                string message = Encoding.UTF8.GetString(data);

                Dispatcher.Invoke(() =>
                {
                    MessagesList.Items.Add(message);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                udpClient.BeginReceive(Receive, null);
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            IPEndPoint endPoint = new IPEndPoint(address, port);

            string message = MessageText.Text;
            byte[] data = Encoding.UTF8.GetBytes(message);
            
            udpClient.Send(data, data.Length, endPoint);

            MessageText.Text = string.Empty;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            udpClient.Close();
        }
    }
}
