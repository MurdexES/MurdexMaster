using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using ECommerceApp_Client.Services.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Client.ViewModel
{
    public class MenStoreViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ObservableCollection<ProductModel> Products { get; set; } = new()
        {
            new ProductModel("title", 14.99f, "description", 1, "brand", "productImage", 2),
            new ProductModel("tii", 14.99f, "descdfdfription", 1, "brafdfdnd", "producfdftImage", 2),
            new ProductModel("ti", 14.99f, "description", 1, "brand", "productImage", 2),
            new ProductModel("tiii", 14.99f, "descdfdfription", 1, "brafdfdnd", "producfdftImage", 2),
            new ProductModel("titlei", 14.99f, "description", 1, "brand", "productImage", 2),
            new ProductModel("tiiii", 14.99f, "descdfdfription", 1, "brafdfdnd", "producfdftImage", 2),
            new ProductModel("titleii", 14.99f, "description", 1, "brand", "productImage", 2),
            new ProductModel("tiiiii", 14.99f, "descdfdfription", 1, "brafdfdnd", "producfdftImage", 2),
            new ProductModel("titleiii", 14.99f, "description", 1, "brand", "productImage", 2),
            new ProductModel("tiiiiiiiii", 14.99f, "descdfdfription", 1, "brafdfdnd", "producfdftImage", 2),
            new ProductModel("titleiiii", 14.99f, "description", 1, "brand", "productImage", 2),
            new ProductModel("tiiiiiiiiii", 14.99f, "descdfdfription", 1, "brafdfdnd", "producfdftImage", 2),
            new ProductModel("titleii", 14.99f, "description", 1, "brand", "productImage", 2),
            new ProductModel("t", 14.99f, "descdfdfription", 1, "brafdfdnd", "producfdftImage", 2)
        };

        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;
        private readonly IMyNavigationService _myNavigationService;

        public MenStoreViewModel(IMessenger messenger, ISerializeService serializeService, IMyNavigationService myNavigationService)
        {
            _messenger = messenger;
            _serializeService = serializeService;
            _myNavigationService = myNavigationService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand<object> AddCommand
        {
            get => new(title =>
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Title == title)
                    {
                        _myNavigationService.NavigateToBasket<BasketViewModel>(Products[i]);
                        MessageBox.Show($"{title} is Added To Cart", "Cart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            });
        }
    }
}
