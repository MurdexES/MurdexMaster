using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using ECommerceApp_Client.Services.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Client.ViewModel
{
    public class MenStoreViewModel : ViewModelBase, INotifyPropertyChanged, INotifyCollectionChanged
    {
        public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();

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

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnCollectionChange(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }

        public void MenStoreStartUp()
        {
            using FileStream fs = new(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\male_products.json", FileMode.Open, FileAccess.Read);
            using StreamReader sr = new(fs);
            
            fs.Position = 0;
            
            Products = JsonSerializer.Deserialize<ObservableCollection<ProductModel>>(sr.ReadToEnd());
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
