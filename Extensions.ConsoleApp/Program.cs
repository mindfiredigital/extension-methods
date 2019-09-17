using Extension.Methods;
using System;
using System.Collections.Generic;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 1, 2, 4, 8, 5, 3, 0 };
            l.Sort();
            l.InsertSorted(0);
            Console.ReadKey();
        }
    }
}
