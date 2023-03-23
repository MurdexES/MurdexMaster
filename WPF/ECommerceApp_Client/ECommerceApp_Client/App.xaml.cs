using ECommerceApp_Client.Services.Classes;
using ECommerceApp_Client.Services.Interfaces;
using ECommerceApp_Client.View;
using ECommerceApp_Client.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            MainStartup();
        }

        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();

            Container.RegisterSingleton<IMyNavigationService, NavigationService>();
            Container.RegisterSingleton<ISerializeService, SerializeService>();
            Container.RegisterSingleton<IUserManageService, UserManageService>();
            
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegisterViewModel>();
            Container.RegisterSingleton<BasketViewModel>();
            Container.RegisterSingleton<AboutUsViewModel>();
            Container.RegisterSingleton<ItemViewModel>();
            Container.RegisterSingleton<MenStoreViewModel>();
            Container.RegisterSingleton<WomenStoreViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainWindowView();
            mainView.DataContext = Container.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
