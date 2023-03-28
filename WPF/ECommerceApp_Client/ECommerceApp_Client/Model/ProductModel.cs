using ECommerceApp_Client.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ECommerceApp_Client.Model
{
    public enum Categories
    {
        Sneakers,
        Running,
        Basketball,
    }
    public class ProductModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        private int _quantity = 1;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChange(nameof(Quantity));
            }
        }

        public string Brand { get; set; }
        public bool IsMale { get; set; }
        public string ProductImage { get; set; }

        private int _categorySelect;
        public int CategorySelect
        {
            get => _categorySelect;
            set
            {
                _categorySelect = value;

                if (value == 1)
                {
                    Category = Categories.Sneakers;
                }
                else if (value == 2)
                {
                    Category = Categories.Running;
                }
                else if (value == 3)
                {
                    Category = Categories.Basketball;
                }
            }
        }

        private Categories _category;
        public Categories Category
        {
            get => _category;
            set
            {
                _category = value;
            }
        }

        public ProductModel() { }
        public ProductModel(string title, float price, string description, int quantity, string brand, string productImage, int categorySelect)
        {
            Title = title;
            Price = price;
            Description = description;
            Quantity = quantity;
            Brand = brand;
            ProductImage = productImage;
            CategorySelect = categorySelect;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
