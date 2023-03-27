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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ECommerceApp_Client.ViewModel
{
    public class BasketViewModel : ViewModelBase, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private float _total = 0;
        public float Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChange(nameof(Total));
            }
        }

        public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();
        
        private CardModel _card = new CardModel();
        public CardModel Card
        {
            get { return _card; }
            set
            {
                _card = value;
            }
        }
        
        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;  

        public void ReceiveBasketMessage(BasketMessage message)
        {
            bool key = false;

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Title == message.Product.Title)
                {
                    Products[i].Quantity++;
                    Total += message.Product.Price;

                    key = true;
                }
            }

            if (key == false)
            {
                AddToBasket(message.Product);
            }
        }

        public BasketViewModel(IMessenger messenger, ISerializeService serializeService)
        {
            _messenger = messenger;
            _serializeService = serializeService;

            _messenger.Register<BasketMessage>(this, ReceiveBasketMessage);   
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

        protected void AddToBasket(ProductModel product)
        {
            Products.Add(product);
            Total += product.Price;

            OnCollectionChange(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Products));
        }

        public RelayCommand<object> DeleteProductCommand
        {
            get => new(title =>
            {
                int i = 0;
                while (Products[i].Title != title)
                {
                    i++;
                }

                Total -= (Products[i].Price * Products[i].Quantity);
                Products[i].Quantity = 1;

                Products.RemoveAt(i);
            });
        }

        public RelayCommand MasterCardCommand
        {
            get => new(() =>
            {
                Card.CardType = CardTypes.MasterCard;
            });
        }

        public RelayCommand VisaCommand
        {
            get => new(() =>
            {
                Card.CardType = CardTypes.Visa;
            });
        }

        public RelayCommand AnotherCommand
        {
            get => new(() =>
            {
                Card.CardType = CardTypes.AnotherCard;
            });
        }

        public RelayCommand CheckoutCommand
        {
            get => new(() =>
            {
                if (Products.Count >= 1 && Card != null && Total != 0 && Products != null)
                {
                    if (Card.CardNumber != string.Empty && Card.CardCVV != string.Empty && Card.CardExpireDate != null)
                    {
                        var json = _serializeService.Serialize<ObservableCollection<ProductModel>>(Products);

                        using FileStream fs = new("basket_data.json", FileMode.OpenOrCreate);
                        using StreamWriter sw = new(fs);
                        sw.Write(json);
                    }

                    MessageBox.Show("We sent Check to your Email address.","Checkout Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("There`re nothing in the Basket to Checkout! Add something to Basket.", "Checkout Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

    }
}
