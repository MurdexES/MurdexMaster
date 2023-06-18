using CountriesEF_HW.Model;
using CountriesEF_HW.Model.DBContexts;
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

namespace CountriesEF_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CountriesContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new CountriesContext();
            LoadCountries();
        }

        private void LoadCountries()
        {
            CountriesLV.ItemsSource = context.Countries.ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFilter = SortCB.SelectedIndex;
            IQueryable<Country> query;

            using (var dbContext = new CountriesContext())
            {
                switch (selectedFilter)
                {
                    case 0:
                        query = dbContext.Countries.OrderBy(c => c.Population);
                        break;
                    case 1:
                        query = dbContext.Countries.OrderBy(c => c.GDP);
                        break;
                    case 2:
                        query = dbContext.Countries.OrderBy(c => c.Name);
                        break;
                    default:
                        query = dbContext.Countries;
                        break;
                }

                CountriesLV.ItemsSource = query.ToList();
            }
        }
    }
}
