using People_MVP.Model;
using People_MVP.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_MVP.View
{
    public partial class MainView : Form
    {
        public Person Person { get; set; } = new Person();
        public MainView()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Regex re = new Regex("^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$");
            Regex re2 = new Regex("^[1-9][0-9]*");

            if (re.IsMatch(nameTextBox.Text) && re.IsMatch(surnameTextBox.Text) && re2.IsMatch(ageTextBox.Text))
            {
                Person.Name = nameTextBox.Text;
                Person.Surname = surnameTextBox.Text;
                Person.Age = Convert.ToInt32(ageTextBox.Text);

                peopleListBox.Items.Add(Person);

                nameTextBox.Text = "";
                surnameTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Enter valid info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void peopleListBox_DoubleClick(object sender, EventArgs e)
        {
            InfoFormView form = new InfoFormView(Person);
            form.ShowDialog();

            peopleListBox.Items.RemoveAt(peopleListBox.SelectedIndex);
            peopleListBox.Items.Add(form.person);
        }

        private void imgButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Person.ImagePath = dialog.FileName;
            }
            imgLabel.Text = dialog.FileName;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("people_data.json", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(JsonSerializer.Serialize(peopleListBox.Items));

            sw.Close();
            fs.Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            peopleListBox.Items.RemoveAt(peopleListBox.SelectedIndex);
        }
    }
}
