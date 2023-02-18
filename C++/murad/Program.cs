using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace murad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            emily();
        }
        static void murad()
        {
            int a = 3;
            double b = 4.5;
            int c = 6;
            double d = 4.5;

            if (b == d)
            {
                Console.WriteLine("the numbers are same");
            }
            else
            {
                Console.WriteLine("the numbers are not same");
            }


        }
        static void emily()
        {
            Console.WriteLine("the bread costs 2 manat");
            Console.WriteLine("How many breads did you buy");
            int Number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Your total payment is:{2* Number}");
        }



    }
   
}
