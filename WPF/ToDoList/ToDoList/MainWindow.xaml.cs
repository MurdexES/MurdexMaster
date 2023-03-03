using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using ToDoList.Model;
using ToDoList.View;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Do> DoList { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindowView addWindowView = new AddWindowView();
            addWindowView.ShowDialog();

            DoList.Add(addWindowView.GetDo());
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            DoList.RemoveAt(MainListView.SelectedIndex);
        }
    }
}
