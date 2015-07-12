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
            Red = 5,
            Green = 3,
            Blue = 7
        }
        struct tStruct
        {
            public string name;
            public int age;
            public char sex;

        }
        static void Main(string[] args)
        {
            int myInt = 4;
            double myDouble = myInt + 0.3;
            myInt = (int)myDouble;
            char myC = 'a';
            Console.WriteLine("{0}, {1}, {2}",myDouble,myInt,myC);
            
            // user defined value types

            Color myColor = Color.Red;
            Console.WriteLine("{0} and its integer value = {1}",myColor, (int)myColor);

            tStruct myStruct;
            myStruct.age = 28;
            myStruct.sex = 'M';
            myStruct.name = "Alex";
            Console.WriteLine("{0}, {1}, {2}", myStruct.name, myStruct.sex, myStruct.age);
        }
    }
}