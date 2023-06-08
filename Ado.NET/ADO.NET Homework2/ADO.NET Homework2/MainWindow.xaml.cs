using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.SqlClient;
using Microsoft.SqlServer;
using Microsoft.Data.SqlClient;

namespace ADO.NET_Homework2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = "Data Source=localhost;Database=ProductsDB;Trusted_Connection=True;";
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>() { new Product("name", "desc", 14f, "brand") , new Product("name", "desc", 22, "brand") , new Product("name", "desc", 5, "brand") };


        public MainWindow()
        {
            InitializeComponent();
            OnStartUp(connectionString);
            ProductsIC.ItemsSource = Products;
        }


        private void OnStartUp(string conn)
        {
            using SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string selectQuery = "SELECT ProdName, ProdBrand, ProdPrice, ProdDesc FROM Products";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string productName = reader.GetString(1);
                string productDesc = reader.GetString(2);
                string productPrice = reader.GetString(3);
                string productBrand = reader.GetString(4);

                Product tmpProduct = new Product(productName, productDesc, Convert.ToSingle(productPrice), productBrand);

                Products.Add(tmpProduct);
            }

            reader.Close();
            connection.Close();
        }

        private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool key = false;

            switch(((ComboBoxItem)Filter.SelectedItem).Content)
            {
                case "From Low To High":
                    key = false; break;
                case "From High To Low":
                    key = true; break;
            }

            if (key == false)
            {
                Products.OrderBy(p => p.Price).ToList();
            }
            else if (key)
            {
                Products.OrderByDescending(p => p.Price).ToList();
            }
        }
    }
}

