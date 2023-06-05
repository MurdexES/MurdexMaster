using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ADO.NET_Homework2
{
    public class Product : INotifyPropertyChanged
    {
        public Product() { }
        public Product(string name, string description, float price, string brand)
        {
            Name = name; 
            Description = description; 
            Price = price; 
            Brand = brand;
        }

        private string name;
        public string Name 
        { 
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private float price;
        public float Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        private string brand;
        public string Brand
        {
            get { return brand; }
            set
            {
                if (brand != value)
                {
                    brand = value;
                    OnPropertyChanged(nameof(Brand));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
