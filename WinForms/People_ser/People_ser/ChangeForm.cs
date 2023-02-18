using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_ser
{
    public partial class ChangeForm : Form
    {
        public string GetNameChangeForm { get; set; }

        public string GetSurnameChangeForm { get; set; }

        public string GetAgeChangeForm { get; set; }

        public ChangeForm()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            Regex re = new Regex("^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$");
            Regex re2 = new Regex("^[1-9][0-9]*");

            if (re.IsMatch(textBox1.Text) && re.IsMatch(textBox2.Text) && re2.IsMatch(textBox3.Text))
            {
                GetNameChangeForm = textBox1.Text;
                GetSurnameChangeForm = textBox2.Text;
                GetAgeChangeForm = textBox3.Text;
            }
            else
            {
                MessageBox.Show("Enter valid info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
