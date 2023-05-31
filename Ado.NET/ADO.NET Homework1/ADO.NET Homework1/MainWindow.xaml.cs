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
using System.Collections;
using Microsoft.SqlServer;
using Microsoft.Data.SqlClient;

namespace ADO.NET_Homework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AllClick(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNU6I5R;Initial Catalog=AcademyDB;Integrated Security=True");
            conn.Open();

            var query = new SqlCommand("SELECT * FROM [Students]", conn);
            SqlDataReader reader = query.ExecuteReader();
            var schema = reader.GetColumnSchema();

            foreach (var column in schema)
            {
                DataRes.Text += $"{column.ColumnName}\t";
            }

            while (reader.Read())
            {
                DataRes.Text += $"\n{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetInt32(3)}";
            }
            conn.Close();
        }

        private void MaxClick(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNU6I5R;Initial Catalog=AcademyDB;Integrated Security=True");
            conn.Open();

            var query = new SqlCommand($"SELECT MAX(Rating) FROM [Students]", conn);
            var reader = query.ExecuteScalar();
            DataRes.Text = reader.ToString();
        }

        private void MinClick(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNU6I5R;Initial Catalog=AcademyDB;Integrated Security=True");
            conn.Open();

            var query = new SqlCommand($"SELECT MIN(Rating) FROM [Students]", conn);
            var reader = query.ExecuteScalar();
            DataRes.Text = reader.ToString();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNU6I5R;Initial Catalog=AcademyDB;Integrated Security=True");
            conn.Open();

            var query = new SqlCommand(Query.Text, conn);

            SqlDataReader reader = query.ExecuteReader();
            var schema = reader.GetColumnSchema();

            foreach (var column in schema)
            {
                DataRes.Text += $"{column.ColumnName} \t";
            }

            while (reader.Read())
            {
                DataRes.Text += $"\n{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetInt32(3)}";
            }
            conn.Close();
        }
    }
}
