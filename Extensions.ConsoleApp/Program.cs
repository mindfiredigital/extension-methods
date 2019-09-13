using System;
using System.Collections.Generic;
using System.Globalization;
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
            double number;
            number = 12345.00000678900000000;

            decimal number2;
            number2 = 12345.00000678900000000M;
            Console.WriteLine(number.RemoveTraillingZeros());
            Console.WriteLine(number2.RemoveTraillingZeros());
            Console.ReadKey();
        }
    }
}
