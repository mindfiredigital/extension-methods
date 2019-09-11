using System;
using System.Linq;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /** Remove sample **/
            string founder = "Mahesh Chand is a founder of C# Corner";
            Console.WriteLine(founder.RemoveCharsIgnoreCase('m','A'));
            Console.ReadKey();
        }
    }
}
