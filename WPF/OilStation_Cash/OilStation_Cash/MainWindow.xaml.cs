using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OilStation_Cash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            TotalPriceText.Content = (Single.Parse(GasStationTotalText.Content.ToString()) + Single.Parse(CafeTotalText.Content.ToString())).ToString();
        }

        private void FuelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ComboBoxItem)FuelComboBox.SelectedItem).Content)
            {
                case "A-92":
                    FuelPriceLabel.Content = "4.00";
                    break;
                case "A-94":
                    FuelPriceLabel.Content = "4.50";
                    break;
                case "A-96":
                    FuelPriceLabel.Content = "5.20";
                    break;
                case "Premium":
                    FuelPriceLabel.Content = "6.00";
                    break;
                default:
                    break;
            }
        }

        private void FuelAmountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(FuelAmountRadioButton.IsChecked == true) 
            {
                AmountTextBox.IsReadOnly = false;
                
                PriceTextBox.IsReadOnly = true;
                PriceTextBox.Text = string.Empty;

                FuelPriceRadioButton.IsChecked = false;
            }
        }

        private void FuelPriceRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(FuelPriceRadioButton.IsChecked == true)
            {
                PriceTextBox.IsReadOnly = false;
                
                AmountTextBox.IsReadOnly = true;
                AmountTextBox.Text = string.Empty;

                FuelAmountRadioButton.IsChecked = false;
            }
        }

        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(AmountTextBox.Text != string.Empty) 
            {
                GasStationTotalText.Content = (Single.Parse(AmountTextBox.Text.ToString()) * Single.Parse(FuelPriceLabel.Content.ToString())).ToString();
                PriceTextBox.Text = (Single.Parse(AmountTextBox.Text.ToString()) * Single.Parse(FuelPriceLabel.Content.ToString())).ToString();
            }
        }

        private void PriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PriceTextBox.Text != string.Empty)
            {
                GasStationTotalText.Content = PriceTextBox.Text;
                AmountTextBox.Text = (Single.Parse(PriceTextBox.Text.ToString()) / Single.Parse(FuelPriceLabel.Content.ToString())).ToString();
            }
        }

        private void HotDogCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            HotDogAmountTextBox.IsReadOnly = false;
        }

        private void HamburgerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            HamburgerAmountTextBox.IsReadOnly = false;
        }

        private void FrenchFriesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FrenchFriesAmountTextBox.IsReadOnly = false;
        }

        private void CocaColaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CocaColaAmountTextBox.IsReadOnly = false;
        }

        private void HotDogAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HotDogAmountTextBox.Text != string.Empty)
            {
                CafeTotalText.Content = (Convert.ToDouble(HotDogAmountTextBox.Text.ToString()) * 4.0 + (CafeTotalText.Content == null ? 0.0 : Convert.ToDouble(CafeTotalText.Content.ToString()))).ToString();
            }
        }

        private void HamburgerAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HamburgerAmountTextBox.Text != string.Empty)
            {
                CafeTotalText.Content = (Convert.ToDouble(HamburgerAmountTextBox.Text.ToString()) * 4.0 + (CafeTotalText.Content == null ? 0.0 : Convert.ToDouble(CafeTotalText.Content.ToString()))).ToString();
            }
        }

        private void FrenchFriesAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FrenchFriesAmountTextBox.Text != string.Empty)
            {
                CafeTotalText.Content = (Convert.ToDouble(FrenchFriesAmountTextBox.Text.ToString()) * 4.0 + (CafeTotalText.Content == null ? 0.0 : Convert.ToDouble(CafeTotalText.Content.ToString()))).ToString();
            }
        }

        private void CocaColaAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CocaColaAmountTextBox.Text != string.Empty)
            {
                CafeTotalText.Content = (Convert.ToDouble(CocaColaAmountTextBox.Text.ToString()) * 4.0 + (CafeTotalText.Content == null ? 0.0 : Convert.ToDouble(CafeTotalText.Content.ToString()))).ToString();
            }
        }
    }
}
