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
using System.Windows.Shapes;
using ToDoList.Model;

namespace ToDoList.View
{
    /// <summary>
    /// Interaction logic for AddWindowView.xaml
    /// </summary>
    public partial class AddWindowView : Window
    {
        public Do TmpDo { get; set; } = new Do("NAME", "DeeQSDADADA", Do.ToDoType.Home);
        public AddWindowView()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (DoNameTextBox.Text != string.Empty && DoDescriptionTextBox.Text != string.Empty && DoTypeComboBox.SelectedItem != null)
            {
                TmpDo.Name = DoNameTextBox.Text;
                TmpDo.Description = DoDescriptionTextBox.Text;

                switch (((ComboBoxItem)DoTypeComboBox.SelectedItem).Content.ToString())
                {
                    case "Work":
                        TmpDo.Type = Do.ToDoType.Work;
                        break;
                    case "Home":
                        TmpDo.Type = Do.ToDoType.Home;
                        break;
                    case "Hobby":
                        TmpDo.Type = Do.ToDoType.Hobby;
                        break;
                    case "Private":
                        TmpDo.Type = Do.ToDoType.Private;
                        break;
                    case "Emergency":
                        TmpDo.Type = Do.ToDoType.Emergency;
                        break;
                    default:
                        break;
                }

                Close();
            }
            else
            {
                MessageBox.Show("UnValid Data to add Do");
            }
        }

        public Do GetDo()
        {
            return TmpDo;
        }
    }
}
