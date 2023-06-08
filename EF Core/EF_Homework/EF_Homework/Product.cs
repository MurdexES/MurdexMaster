using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Homework
{
    public class Product
    {
        public Product() { }
        public Product(string name, string description, float price, string brand)
        {
            Name = name;
            Description = description;
            Price = price;
            Brand = brand;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Brand { get; set; }
    }
}
