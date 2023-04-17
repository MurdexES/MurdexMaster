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

namespace DocumentarySlavery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Document> Documents { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Documents.Count <= 1) 
            {
                Documents.Add(new Document("Empty", "Empty", 16));
            }
            else
            {
                var tmp = Documents[0].Clone() as Document;
                Documents.Add(tmp);
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text != string.Empty && TextTB.Text != string.Empty && FontSizeTB.Text != string.Empty)
            {
                Documents[0].Name = NameTB.Text;
                Documents[0].Text = TextTB.Text;
                Documents[0].FontSize = Convert.ToInt32(FontSizeTB.Text);

                for (int i = 0; i < Documents.Count; i++)
                {
                    Documents[i] = Documents[0].Clone() as Document;
                }
            }
            else
            {
                MessageBox.Show("Invalid entered data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Documents.Remove(MainListView.SelectedItem as Document);
        }

        private void FontSizeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(FontSizeTB.Text, "^[0-9]*$"))
            {
                FontSizeTB.Text = string.Empty;
            }
        }
    }
}
