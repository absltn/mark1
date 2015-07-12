using System;

namespace Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            int testInt = 10;
            Console.WriteLine("Hello world! ");
            Console.WriteLine("Current Date and Time: {0}", DateTime.Now.ToString());
        }
    }
}
