using System;
using System.Net;

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

            foreach (HttpStatusCode c in Enum.GetValues(typeof(HttpStatusCode)))
            {
                Console.WriteLine("Name:{0} - {1} - {2} - {3}", c, c.ToString(), c.ToString().ToHumanCase(), c.ToHumanCase());
            }
            Console.ReadKey();
        }
    }
}
