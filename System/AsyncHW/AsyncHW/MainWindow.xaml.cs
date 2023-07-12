using AsyncHW.Data;
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
            LoadCountries();
        }

        private void LoadCountries()
        {
            CountriesLB.ItemsSource = countryContext.Countries.ToList();
        }

        public async Task CreateAsync(Country country)
        {
            using (var context = new CountriesContext())
            {
                context.Countries.Add(country);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Country country)
        {
            using (countryContext)
            {
                countryContext.Countries.Remove(country);
                await countryContext.SaveChangesAsync();
            }
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

                await CreateAsync(country);
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

            await DeleteAsync(country);
        }
    }
}
