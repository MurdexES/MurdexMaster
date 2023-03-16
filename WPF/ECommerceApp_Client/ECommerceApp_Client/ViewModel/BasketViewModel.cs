using ECommerceApp_Client.Model;
using ECommerceApp_Client.Services.Interfaces;
using ECommerceApp_Client.Services.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ECommerceApp_Client.ViewModel
{
    public class BasketViewModel : ViewModelBase
    {
        public BasketModel Basket { get; set; } = new();
        public CardModel Card { get; set; } = new();

        private static int iter = 0;
        
        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;  

        public BasketViewModel(IMessenger messenger, ISerializeService serializeService)
        {
            _messenger = messenger;
            _serializeService = serializeService;

            _messenger.Register<DataMessages>(this, messenger =>
            {
                Basket.Products[iter] = messenger.Data as ProductModel;
                iter++;
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
                if (Basket != null && Card != null)
                {
                    var json = _serializeService.Serialize<BasketModel>(Basket);

                    using FileStream fs = new("basket_data.json", FileMode.OpenOrCreate);
                    using StreamWriter sw = new(fs);
                    sw.Write(json);
                }
                else
                {
                    MessageBox.Show("There`re nothing in the Basket to Checkout! Add something to Basket.", "Checkout Error");
                }
            });
        }

    }
}
