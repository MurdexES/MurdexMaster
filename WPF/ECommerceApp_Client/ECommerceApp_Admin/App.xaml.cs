using ECommerceApp_Admin.View;
using ECommerceApp_Admin.ViewModel;
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
            
        }

        private void Register()
        {
            Container.RegisterSingleton<MainViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainWindowView();
            mainView.DataContext = Container.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
