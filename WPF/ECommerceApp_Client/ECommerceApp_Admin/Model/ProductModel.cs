using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ECommerceApp_Admin.Model
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
    }
}
