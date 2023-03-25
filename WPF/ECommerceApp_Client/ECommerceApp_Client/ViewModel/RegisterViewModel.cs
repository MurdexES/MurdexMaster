using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Classes;
using ECommerceApp_Client.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ECommerceApp_Client.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public UserModel User { get; set; } = new();
        public List<string> Operators { get; set; } = new()
        {
            "050",
            "070",
            "055",
            "077",
            "099",
            "010"
        };

        private readonly IMyNavigationService _navigationService;
        private readonly IUserManageService _userService;

        public RegisterViewModel(IMyNavigationService navigationService, IUserManageService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
        }

        public RelayCommand<object> RegisterCommand
        {
            get => new(
            param =>
            {
                if (param != null)
                {
                    object[] res = (object[])param;

                    var password = (PasswordBox)res[0];
                    var confirm = (PasswordBox)res[1];

                    User.Password = password.Password.ToString();
                    _userService.Register(User, confirm.Password.ToString());
                }
            });
        }
    }
}
