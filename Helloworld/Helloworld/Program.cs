﻿using System;

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
            Console.WriteLine(testInt);
        }
    }
}