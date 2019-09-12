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
            string seoUrl = title.SeoFriendlyURL(100);
            Console.WriteLine("Seo url is: {0}", seoUrl);
            Console.ReadKey();
        }
    }
}
