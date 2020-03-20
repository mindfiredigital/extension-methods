using Extension.Methods;
using System;
using System.Collections.Generic;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in "SwagatKumarSwain".SplitCamelCase())
            {

                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
