using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<DateTime> dateRange = DateTime.Now.GetDateRange(DateTime.Now.AddDays(80));
            //foreach (var item in dateRange)
            //{
            //    Console.WriteLine(item.ToMMDDYY());
            //}
            var myNumbers = new List<double?>
                            {
                                null,1,2
                            };
            Console.WriteLine(myNumbers.Sum());
            Console.ReadKey();
        }
    }
}
