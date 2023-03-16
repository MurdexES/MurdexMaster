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
    public class ItemViewModel : ViewModelBase
    {
        public ProductModel Product { get; set; } = new();

        public ItemViewModel() 
        {
            
        }

        public RelayCommand ItemAddCommand
        {
            get => new(() =>
            {
                Product.Quantity += 1;
            });
        }

        public RelayCommand ItemLowCommand
        {
            get => new(() =>
            {
                if (Product.Quantity > 1) 
                { 
                    Product.Quantity -= 1;
                }
                else if (Product.Quantity == 1) 
                {
                    
                }
            });
        }
    }
}
