using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_HW
{
    public class FTPHandler
    {
        public FTPHandler(string _server,  string _port, string _username, string _password)
        {
            ftpServer = _server;
            ftpPort = _port;
            ftpUsername = _username;
            ftpPassword = _password;
        }

        public void Upload()
        {

        }

        public void Download() 
        {
            
        }

        public string ftpServer { get; set; }
        public string ftpPort { get; set; }
        public string ftpUsername { get; set; }
        public string ftpPassword { get; set; }
    }
}
