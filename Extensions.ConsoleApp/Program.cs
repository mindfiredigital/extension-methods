using System;

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
            var today = DateTime.Now;
            foreach (var item in today.GetDateRangeForCurrentWeek())
            {
                Console.WriteLine(item.ToMMDDYY());
            }
            Console.ReadKey();
        }
    }
}
