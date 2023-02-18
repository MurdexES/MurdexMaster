using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string UserText = textBox1.Text;
            int UserNumber = Int32.Parse(textBox1.Text);

            int tmpNumber = new int();
            Random rand = new Random();
            int count = new int();

            if (UserText.ToLower() == "stop")
            {
                return;
            }
            else
            {
                while (tmpNumber != UserNumber)
                {
                    tmpNumber = rand.Next(1, 2000);
                    count++;
                }

                MessageBox.Show($"This is correct number : {tmpNumber.ToString()}. Number of tries : {count}");
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
