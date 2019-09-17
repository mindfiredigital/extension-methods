using Extension.Methods;
using System;
using System.Collections.Generic;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Now;
            var day2 = new DateTime(2020, 01, 02);
            Console.WriteLine($"Date diff (year): {date.ToFriendlyDayString()} - {date.AddDays(-1).ToFriendlyDayString()}");
            Console.WriteLine($"Date diff (month): {date.DateDiff(day2, "month")}");
            Console.WriteLine($"Date diff (day): {date.DateDiff(day2, "day")}");
            Console.WriteLine("9238545725".ToPhoneNumber());
            Console.ReadKey();
        }
    }
}
