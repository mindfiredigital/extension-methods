using System;
using System.Linq;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Title");
            string title = Console.ReadLine();
            string seoUrl = title.ToTitleCase();
            Console.WriteLine("ToTitleCase is: {0}", seoUrl);
            Console.ReadKey();
        }
    }
}
