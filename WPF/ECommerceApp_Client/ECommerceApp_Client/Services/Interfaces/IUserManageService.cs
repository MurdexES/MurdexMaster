using ECommerceApp_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Services.Interfaces
{
    public interface IUserManageService
    {
        void Add(UserModel user);

        UserModel GetUser(string username, string password);
        bool CheckExists(string username, string password);
    }
}
