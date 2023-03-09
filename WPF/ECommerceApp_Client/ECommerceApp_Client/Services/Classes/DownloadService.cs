using ECommerceApp_Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Services.Classes
{
    public class DownloadService : IDownloadService
    {
        public string DownloadJson(string search)
        {
            WebClient client = new();

            return String.Empty;
        }
    }
}
