using Extension.Methods;
using System;
using System.Collections.Generic;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 1, 2, 4, 8, 5, 3 };
            l.Sort();

            // Sort the list before calling InsertSorted().
            // The method below inserts 6 at the appropriate position inside the sorted list.
            l.InsertSorted(6);

            // Extension Method ToString(", ") would make your list nicely formatted with comma separated.
            Console.WriteLine(l.ToString(", "));
          
            Console.ReadKey();
        }
    }
}
