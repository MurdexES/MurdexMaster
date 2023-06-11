using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EFCodeFirst;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyDbContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new MyDbContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text.ToString();
            string desc = DescriptionTB.Text.ToString();
            float price = Single.Parse(PriceTB.Text);
            string brand = BrandTB.Text.ToString();

            Product product = new Product(name, desc, price, brand);

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            MessageBox.Show("Product added!");

            NameTB.Clear();
            DescriptionTB.Clear();
            PriceTB.Clear();
            BrandTB.Clear();
        }
    }
}
