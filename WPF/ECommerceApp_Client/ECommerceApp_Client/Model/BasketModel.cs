using ECommerceApp_Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Client.Model
{
    public class BasketModel
    {
        public ObservableCollection<ProductModel> Products {  get; set; }
        public float Total { get; set; }
    }
}
