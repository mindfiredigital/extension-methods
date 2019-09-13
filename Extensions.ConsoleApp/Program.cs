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
            var nums = Enumerable.Range(0, 18);
            var split = nums.Split(5);

            foreach (var item in split)
            {
                foreach (var inner in item)
                {
                    Console.WriteLine(inner);
                }
                Console.WriteLine("----------------");
            }

            Console.ReadKey();
        }
    }
}
