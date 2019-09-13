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
            //Console.WriteLine(string.Format("{0:(###) ###-####}", 8005551212));
            //var data = new string[] { "(123) 556 -7890", "123 556 7890", "(123) 556 - 7890", "11111111111" };
            //foreach (var s in data)
            //{
            //    Console.WriteLine(s.MaskPhoneNumber('#'));
            //}
            //Console.WriteLine("ssswagatss@gmail.com".MaskEmail('#'));
            List<DayOfWeek> weekdays = EnumExtensions.EnumToList<DayOfWeek>().ToList();
            foreach (var w in weekdays)
            {
                Console.WriteLine(w);
            }

            var monday = "Monday".ToEnum<DayOfWeek>();

            Console.ReadKey();
        }
    }
}
