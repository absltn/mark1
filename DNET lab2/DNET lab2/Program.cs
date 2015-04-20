using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNET_lab2
{
    class Program
    {
        enum Color
        {
            Red = 4,
            Green = 3,
            Blue = 7
        }
        static void Main(string[] args)
        {
            int myInt = 4;
            double myDouble = myInt + 0.3;
            myInt = (int)myDouble;
            char myC = 'a';
            Console.WriteLine("{0}, {1}, {2}",myDouble,myInt,myC);
            
            Color myColor = Color.Red;
            Console.WriteLine("{0} and its integer value = {1}",myColor, (int)myColor);
        }
    }
}