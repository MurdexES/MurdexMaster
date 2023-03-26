using ECommerceApp_Admin.Model;
using ECommerceApp_Admin.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Admin.ViewModel
{
    public class AddViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IMyNavigationService _navigationService;

        private ProductModel _product = new ProductModel();
        public ProductModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChange(nameof(Product));
            }
        }

        public AddViewModel(IMyNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand ImagePickCommand
        {
            get => new(() =>
            {
                var dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

                var result = dialog.ShowDialog();
                if (result == true)
                {
                    Product.ProductImage = (string)dialog.FileName;
                }
            });
        }

        public RelayCommand AcceptCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateDataTo<MainViewModel>(Product);
                Product = new ProductModel();
            });
        }

        public RelayCommand MenCommand
        {
            get => new(() =>
            {
                Product.IsMale = true;
            });
        }

        public RelayCommand WomenCommand
        {
            get => new(() =>
            {
                Product.IsMale = false;
            });
        }
    }
}
