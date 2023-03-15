using ECommerceApp_Client.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.ViewModel
{
    public class BasketViewModel : ViewModelBase
    {
        public BasketModel Basket { get; set; }

    }
}
