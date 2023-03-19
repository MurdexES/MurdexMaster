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
        public ObservableCollection<ProductViewModel> ProductViews { get; set; } = new(); 

        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;
        private readonly IMyNavigationService _myNavigationService;

        public MenStoreViewModel(IMessenger messenger, ISerializeService serializeService, IMyNavigationService myNavigationService)
        {
            _messenger = messenger;
            _serializeService = serializeService;
            _myNavigationService = myNavigationService;

            _messenger.Register<DataMessages>(this, messenger =>
            {
                ProductViews = messenger.Data as ObservableCollection<ProductViewModel>;
            });
        }

        //public RelayCommand SerlCommand
        //{
        //    get => new(() =>
        //    {
        //        string? json = _serializeService.Serialize<ProductModel>();
        //        using FileStream fs = new("newdata.json", FileMode.OpenOrCreate);
        //        using StreamWriter sw = new(fs);
        //        sw.Write(json);
        //    });
        //}
    }
}
