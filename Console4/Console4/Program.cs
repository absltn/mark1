using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console4
{
    class Program
    {
        class myClass
        {
            private int x;
            public int WriteX()
            {
                string imp = Console.ReadLine();
                Int32.TryParse(imp, out x);
                return x;
            }
            public void Write()
            {
                Console.WriteLine(x);
            }
        }

        static void Main(string[] args)
        {
            myClass test = new myClass();
            test.WriteX();
            test.Write();
        }
    }
}
