using ECommerceApp_Admin.Services.Classes;
using ECommerceApp_Admin.Services.Interfaces;
using ECommerceApp_Admin.View;
using ECommerceApp_Admin.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Admin
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

            Container.RegisterSingleton<ISerializeService, SerializeService>();
            Container.RegisterSingleton<IMyNavigationService, MyNavigationService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AddViewModel>();
            Container.RegisterSingleton<DeleteViewModel>();
            Container.RegisterSingleton<ChangeViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainWindowView();
            mainView.DataContext = Container.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
