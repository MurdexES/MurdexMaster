using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        public ProductModel Product { get; set; } = new();

        private readonly IMyNavigationService _navigationService;

        public ProductViewModel(IMyNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand AddProduct
        {
            get => new(() =>
            {
                _navigationService.NavigateDataTo<BasketViewModel>(Product);
            });
        }
    }
}
