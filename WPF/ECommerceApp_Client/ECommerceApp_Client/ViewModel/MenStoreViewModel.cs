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
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceApp_Client.ViewModel
{
    public class MenStoreViewModel : ViewModelBase
    {
        public ObservableCollection<ProductModel> Products { get; set; } = new(); 

        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;

        public ProductModel Product { get; set; } = new ProductModel("Guest", 14.9f, "Good", 4, "Brand", "Assets/close_icon.png");
        public MenStoreViewModel(IMessenger messenger, ISerializeService serializeService)
        {
            _messenger = messenger;
            _serializeService = serializeService;

            _messenger.Register<DataMessages>(this, messenger =>
            {
                Products = messenger.Data as ObservableCollection<ProductModel>;
            });
        }

        public RelayCommand SerlCommand
        {
            get => new(() =>
            {
                string? json = _serializeService.Serialize<ProductModel>(Product);
                using FileStream fs = new("newdata.json", FileMode.OpenOrCreate);
                using StreamWriter sw = new(fs);
                sw.Write(json);
            });
        }
    }
}
