using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Services.Classes
{
    public class UserManageService : IUserManageService
    {
        private List<UserModel> Users = new();
        private readonly ISerializeService _serializeService;

        public UserManageService(ISerializeService service)
        {
            _serializeService = service;
        }

        private string CheckLength()
        {
            var res = File.ReadAllText("data.json");
            return res;
        }

        public void Add(UserModel user)
        {
            var check = CheckLength();

            using FileStream fs = new("data.json", FileMode.Truncate);
            using StreamReader sr = new(fs);
            using StreamWriter sw = new(fs);

            var json = sr.ReadToEnd();

            if (check.Length > 1)
            {
                Users = _serializeService.Deserialize<List<UserModel>>(check);
            }
            Users.Add(user);
            json = _serializeService.Serialize<List<UserModel>>(Users);
            sw.Write(json);

        }

        private UserModel? DownloadData(string username, string password)
        {
            using FileStream fs = new("data.json", FileMode.Open);
            using StreamReader sr = new(fs);

            Users = _serializeService.Deserialize<List<UserModel>>(sr.ReadToEnd());

            var result = Users.Find(x => x.Username == username && x.Password == password);

            return result;
        }

        public bool CheckExists(string username, string password)
        {
            var user = DownloadData(username, password);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public UserModel GetUser(string username, string password)
        {
            var user = DownloadData(username, password);

            if (user != null)
            {
                return user;
            }
            throw new NullReferenceException();
        }
    }
}
