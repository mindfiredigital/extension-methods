using Extension.Methods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Decimal value = 106.25m;
            Console.WriteLine("Current Culture: {0}",
                              CultureInfo.CurrentCulture.Name);
            Console.WriteLine("Currency Symbol: {0}",
                              NumberFormatInfo.CurrentInfo.CurrencySymbol);
            Console.WriteLine("Currency Value:  {0:C2}", value);

            Console.ReadKey();

            Console.ReadKey();
        }
    }

    public class Bar
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
