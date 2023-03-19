using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using ECommerceApp_Client.Services.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IMyNavigationService _navigationService;
        private ViewModelBase _currentViewModel;

        Window mainWindow;
        //private UserModel _currentUser;

        //public UserModel CurrentUser
        //{
        //    get => _currentUser;
        //    set
        //    {
        //        Set(ref _currentUser, value);
        //    }
        //}
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

        public void ReceiveMessage(NavigationMessage message)
        {
            CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
        }

        public MainViewModel(IMessenger messenger, IMyNavigationService navigationService)
        {
            CurrentViewModel = App.Container.GetInstance<LoginViewModel>();

            _messenger = messenger;
            _messenger.Register<NavigationMessage>(this, ReceiveMessage);

            _navigationService = navigationService;
        }

        public RelayCommand MenStoreCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<MenStoreViewModel>();
            });
        }

        public RelayCommand WomenStoreCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<WomenStoreViewModel>();
            });
        }

        public RelayCommand BasketCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<BasketViewModel>();
            });
        }

        public RelayCommand AboutUsCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AboutUsViewModel>();
            });
        }

        public RelayCommand AuthCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<LoginViewModel>();
            });
        }
    }
}
