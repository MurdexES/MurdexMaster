using System;
using System.Collections.Generic;
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
    public class ProductModel
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string ProductImage { get; set; }
        public Categories Category { get; set; }

        public ProductModel() { }
        public ProductModel(string title, float price, string description, int quantity, string brand, string productImage, Categories category)
        {
            Title = title;
            Price = price;
            Description = description;
            Quantity = quantity;
            Brand = brand;
            ProductImage = productImage;
            Category = category;
        }
    }
}
