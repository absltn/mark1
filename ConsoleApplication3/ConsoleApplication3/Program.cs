using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 2, b = 4.5;
            double x;
            string usr = Console.ReadLine();
            if (double.TryParse(usr, out x))
            {
                if ((x >= a) && (x <= b))
                {
                    Console.WriteLine("X in AB");
                }
                else
                {
                    Console.WriteLine("X not in AB");
                }
            }
            else Console.WriteLine("Parse problem");
            do
                Console.WriteLine(x);
            while (++x <= 10);
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(i);
            }
            ArrayList number = new ArrayList();


        }
    }
}
