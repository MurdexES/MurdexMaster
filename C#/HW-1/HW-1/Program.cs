using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HW_1;

namespace HW_1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Task1
            //string fact1 = "I am 16 y.o.";
            //string fact2 = "I am studying programming";
            //string fact3 = "I am able to code on c#";

            //int total = (fact1.Length + fact2.Length + fact3.Length);

            //List<string> facts = new List<string>();

            //facts.Add(fact1);
            //facts.Add(fact2);
            //facts.Add(fact3);

            //float avg = total / facts.Count;

            //for (int i = 0; i < 2; i++)
            //{
            //    MessageBox.Show(facts[i]);
            //}

            //MessageBox.Show(facts[2], avg.ToString());
            #endregion
            #region Task2

            Application.Run(new Form1());    

            #endregion
        }
    }
}
