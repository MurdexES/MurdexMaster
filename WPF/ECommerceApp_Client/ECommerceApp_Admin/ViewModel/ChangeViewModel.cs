using ECommerceApp_Admin.Model;
using ECommerceApp_Admin.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Admin.ViewModel
{
    public class ChangeViewModel : ViewModelBase
    {
        public ProductModel Product { get; set; } = new();

        private readonly IMyNavigationService _navigationService;

        public ChangeViewModel(IMyNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand ChangeAcceptCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateChangeTo<MainViewModel>(Product);
            });
        }
    }
}
