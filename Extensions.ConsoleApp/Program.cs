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
            double? pi = null;
            string s = pi.ToString("0.00"); //s = ""
            Console.WriteLine("s : "+s);
            pi = Math.PI;
            s = pi.ToString("0.00");  //s = 3.14
            Console.WriteLine("s : " + s);
            Console.ReadKey();
        }
    }
}
