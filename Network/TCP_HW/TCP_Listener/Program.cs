using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
int port = 8080;

TcpListener tcpListener = new TcpListener(ipAddress, port);

tcpListener.Start();

Console.WriteLine($"Server listening port {port}");

try
{
    TcpClient tcpClient = tcpListener.AcceptTcpClient();

    Console.WriteLine("Client Connected");

    NetworkStream stream = tcpClient.GetStream();

    byte[] buffer = new byte[1024];
    int bytesRead = stream.Read(buffer, 0, buffer.Length);
    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

    Console.WriteLine($"Received message: {request}");

    string response = "Server Heard You";
    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
    stream.Write(responseBytes, 0, responseBytes.Length);
    Console.WriteLine($"Sent message: {response}");

    tcpClient.Close();
}
finally
{
    tcpListener.Stop();
}
