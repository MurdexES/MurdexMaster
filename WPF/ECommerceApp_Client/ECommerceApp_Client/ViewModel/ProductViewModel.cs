using ECommerceApp_Client.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        public ProductModel Product { get; set; }

        public RelayCommand AddProduct
        {
            get => new(() =>
            {

            });
        }
    }
}
