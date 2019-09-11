using System;
using System.Linq;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bar = @"23,34,,56,,-2,33,100";
            var expected = bar.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }
    }
}
