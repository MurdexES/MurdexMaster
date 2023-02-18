using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_ser
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        public InfoForm(Person person)
        {
            InitializeComponent();

            nameLabel.Text = person.Name;
            surnameLabel.Text = person.Surname;
            ageLabel.Text = person.Age.ToString();

            pictureBox.Image = Image.FromFile(person.ImagePath);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            using (ChangeForm changeForm = new ChangeForm()) 
            { 
                if (changeForm.ShowDialog() == DialogResult.OK) 
                {
                    nameLabel.Text = changeForm.GetNameChangeForm;
                    surnameLabel.Text = changeForm.GetSurnameChangeForm;
                    ageLabel.Text = changeForm.GetAgeChangeForm;
                }
            }                       
        }
    }
}
