using ECommerceApp_Admin.Model;
using ECommerceApp_Admin.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Admin.ViewModel
{
    public class DeleteViewModel : ViewModelBase
    {
        public string Brand { get; set; }
        public string Title { get; set; }

        private readonly IMyNavigationService _navigationService;

        public DeleteViewModel(IMyNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand DeleteProductCommand
        {
            get => new(() =>
            {

                _navigationService.NavigateDeleteTo<MainViewModel>(new string[2] {Brand, Title});
            });
        }
    }
}
