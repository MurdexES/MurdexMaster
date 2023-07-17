using System.Net;
using System.Net.Sockets;
using System.Text;

string serverAddress = "127.0.0.1";
int serverPort = 8080;

TcpClient tcpClient = new TcpClient(serverAddress, serverPort);
Console.WriteLine($"Client Connected Port {serverPort}");

NetworkStream stream = tcpClient.GetStream();


string request = "Hello Server";
byte[] requestBytes = Encoding.UTF8.GetBytes(request);
stream.Write(requestBytes, 0, requestBytes.Length);

Console.WriteLine($"Sent message: {request}");


byte[] responseBuffer = new byte[1024];
int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

Console.WriteLine($"Received message: {response}");

tcpClient.Close();
