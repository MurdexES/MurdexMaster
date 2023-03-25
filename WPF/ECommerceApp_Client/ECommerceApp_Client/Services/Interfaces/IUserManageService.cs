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
        public void Authorize(UserModel user);
        public void Register(UserModel user, string confirm);
        public bool CheckExists(UserModel user);
        public UserModel GetUser(string mail, string password);
        public bool CheckInputs(UserModel user, string confirm);
    }
}
