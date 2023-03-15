using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ECommerceApp_Client.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IMyNavigationService _navigationService;
        private readonly IUserManageService _userManageService;
        public string Username { get; set; }

        public LoginViewModel(IMyNavigationService navigationService, IUserManageService userManageService)
        {
            _navigationService = navigationService;
            _userManageService = userManageService;
        }

        public RelayCommand<object> LoginCommand
        {
            get => new(
                param =>
                {
                    try
                    {
                        var password = param as PasswordBox;
                        var user = _userManageService.GetUser(Username, password.Password);

                        MessageBox.Show($"{user.Email} logged in");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("User does not exist");
                    }
                });
        }

        public RelayCommand RegisterCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<RegisterViewModel>();
            });
        }
    }
}
