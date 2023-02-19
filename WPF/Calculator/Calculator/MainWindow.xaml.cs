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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DynamicExpresso;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> Nums { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            string getText = sender.ToString();
            getText = getText[32].ToString();
            
            textNums.Content += getText;

            string? value = textNums.Content.ToString();

            if (value.Length < 10)
            {
                if (((value.Length / 2) + 2) * textNums.FontSize > 550)
                {
                    textNums.FontSize *= 0.8;
                }
            }
            else
            {
                string tmp = string.Empty;
                string text = textNums.Content.ToString();

                MessageBox.Show("Digit number is too many");
                
                for (int i = 0; i < textNums.Content.ToString().Length - 1; i++)
                {
                    tmp += text[i];
                }

                textNums.Content = tmp;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (textNums.Content.ToString() != string.Empty)
            {
                string getText = sender.ToString();
                int num = Convert.ToInt32(textNums.Content);

                getText = getText[32].ToString();
                Nums.Add(num);

                textEquatation.Content += num.ToString();
                textEquatation.Content += getText;
                textNums.Content = string.Empty;
            }
            else
            {
                MessageBox.Show("No Entered Value");
            }
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (textNums.Content.ToString() != string.Empty)
            {
                textEquatation.Content += textNums.Content.ToString();

                var result = new Interpreter().Eval(textEquatation.Content.ToString());

                textNums.Content = result.ToString();
                textEquatation.Content = string.Empty;

                if (result.ToString().Length < 10)
                {
                    if (((result.ToString().Length / 2) + 2) * textNums.FontSize > 600)
                    {
                        textNums.FontSize *= 0.8;
                    }
                }
                else
                {
                    MessageBox.Show("No Entered Value");
                }
            }
            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (textNums.Content != string.Empty)
            {
                textNums.Content = string.Empty;
            }
            else
            {
                for (int i = 0; i < Nums.Count; i++)
                {
                    Nums.RemoveAt(i);
                }
                
                textEquatation.Content = string.Empty;
            }
            
            textNums.FontSize = 200;
        }
    }
}
