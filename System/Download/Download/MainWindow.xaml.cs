using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Download
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Book> Books { get; set; } = new List<Book>
        {
            new Book("The Financier", "Financial book", "Theodore Dreiser"),
            new Book("The Dark Tower", "Fiction Horror", "Stephen King")
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Download()
        {
            for (int i = 0; i < Books.Count; i++) 
            {
                Dispatcher.Invoke(() => BooksLB.Items.Add(Books[i]));
            }
        }

        private void DownloadBT_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new(Download);
            thread.Start();
        }
    }
}
