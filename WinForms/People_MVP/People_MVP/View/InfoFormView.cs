using People_MVP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_MVP.View
{
    public partial class InfoFormView : Form
    {
        public Person person = new Person();
        public InfoFormView()
        {
            InitializeComponent();
        }

        public InfoFormView(Person person)
        {
            InitializeComponent();

            this.person = person;

            nameLabel.Text = person.Name;
            surnameLabel.Text = person.Surname;
            ageLabel.Text = person.Age.ToString();

            pictureBox.Image = Image.FromFile(person.ImagePath);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            using (ChangeFormView changeForm = new ChangeFormView())
            {
                if (changeForm.ShowDialog() == DialogResult.OK)
                {
                    nameLabel.Text = changeForm.GetNameChangeForm;
                    surnameLabel.Text = changeForm.GetSurnameChangeForm;
                    ageLabel.Text = changeForm.GetAgeChangeForm;

                    person.Name = changeForm.GetNameChangeForm;
                    person.Surname = changeForm.GetSurnameChangeForm;
                    person.Age = Int32.Parse(changeForm.GetAgeChangeForm);
                }
            }
        }
    }
}
