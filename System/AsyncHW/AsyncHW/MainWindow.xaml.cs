using AsyncHW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

namespace AsyncHW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CountriesContext countryContext;

        public MainWindow()
        {
            InitializeComponent();
            countryContext = new CountriesContext();
        }

        private async Task ShowCountries()
        {
            CountriesLB.ItemsSource = await countryContext.Countries.ToListAsync();
        }

        private async void CreateBT_Click(object sender, RoutedEventArgs e)
        {
            string name;
            uint yearFounded;
            Country country;

            if (CountryNameTB.Text != null && CountryYearTB.Text != string.Empty)
            {
                name = CountryNameTB.Text.ToString();
                yearFounded = UInt32.Parse(CountryYearTB.Text.ToString());

                country = new Country(name, yearFounded, string.Empty, string.Empty, 0, 0, 0);

                countryContext.Countries.Add(country);

                await countryContext.SaveChangesAsync();
                await ShowCountries();
            }
            else
            {
                MessageBox.Show("No valid info for creation");
            }
        }

        private async void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            Country country;

            country = CountriesLB.SelectedItem as Country;

            countryContext.Countries.Remove(country);

            await countryContext.SaveChangesAsync();
            await ShowCountries();
        }
    }
}
