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

        }

        private void PriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
