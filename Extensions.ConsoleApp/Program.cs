using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] { 1, 2, 3 };
            items.IsSingle(); // returns false
            items.Take(1).IsSingle(); // returns true
            new List<object>().IsSingle(); // returns false
            Console.ReadKey();
        }
    }
}
