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
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.ViewModel
{
    public class WomenStoreViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ObservableCollection<ProductModel> Products { get; set; } = new();
        private int _basketNumber;
        public int BasketNumber
        {
            get { return _basketNumber; }
            set
            {
                _basketNumber = value;
                OnPropertyChange(nameof(BasketNumber));
            }
        }

        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;
        private readonly IMyNavigationService _myNavigationService;

        public WomenStoreViewModel(IMessenger messenger, ISerializeService serializeService, IMyNavigationService myNavigationService)
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
                        _myNavigationService.NavigateDataTo<BasketViewModel>(Products[i]);
                        BasketNumber++;
                    }
                }
            });
        }
    }
}
