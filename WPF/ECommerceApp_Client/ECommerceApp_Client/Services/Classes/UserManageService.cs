using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Client.Services.Classes
{
    public class UserManageService : IUserManageService
    {
        public List<UserModel> Users { get; set; } = new();
        
        private readonly ISerializeService _serializeService;
        private readonly IMyNavigationService _navigationService;
        private readonly IMessenger _messenger;
        
        public UserManageService(ISerializeService serializeService, IMyNavigationService navigationService, IMessenger messenger)
        {
            _serializeService = serializeService;
            _navigationService = navigationService;
            _messenger = messenger;
        }

        public void Authorize(UserModel user)
        {
            using FileStream fs = new("users.json", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);
            if (sr.ReadToEnd() != string.Empty)
            {
                Users = _serializeService.Deserialize<List<UserModel>>(sr.ReadToEnd());
            }
            var result = Users.Find(x => x.Email == user.Email && x.Password == user.Password);

        }

        public void Register(UserModel user, string confirm)
        {
            if (!CheckExists(user) && CheckInputs(user, confirm))
            {
                using FileStream fs = new("users.json", FileMode.OpenOrCreate, FileAccess.Write);
                using StreamWriter sw = new(fs);
                
                Users.Add(user);
                
                sw.Write(JsonSerializer.Serialize(Users));
            }
            else if (CheckExists(user))
            {
                MessageBox.Show("This mail is already used!");
            }

        }

        public bool CheckExists(UserModel user)
        {
            using FileStream fs = new("users.json", FileMode.OpenOrCreate, FileAccess.Read);
            using StreamReader sr = new(fs);

            if (sr.ReadToEnd() != string.Empty)
            {
                fs.Position = 0;
                Users = _serializeService.Deserialize<List<UserModel>>(sr.ReadToEnd());
            }
            
            UserModel res = Users.Find(x => x.Email == user.Email);
            
            return res != null;
        }

        public UserModel GetUser(string mail, string password)
        {
            using FileStream fs = new("users.json", FileMode.OpenOrCreate, FileAccess.Read);
            using StreamReader sr = new(fs);
            
            if (sr.ReadToEnd() != string.Empty)
            {
                fs.Position = 0;
                Users = _serializeService.Deserialize<List<UserModel>>(sr.ReadToEnd());
            }
            
            UserModel result = Users.Find(x => x.Email == mail);

            return result;
        }

        public bool CheckInputs(UserModel user, string confirm)
        {
            if (Regex.IsMatch(user.Email, "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                if (Regex.IsMatch(user.Password, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-_]).{8,}"))
                {
                    if (user.Username.Length > 3)
                    {
                     
                        if (user.Password == confirm)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Passwords don't match!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Userame is too short!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Password doesn't match to our conditions!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("E-Mail doesn't match to our conditions!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            return false;
        }
    }
}
