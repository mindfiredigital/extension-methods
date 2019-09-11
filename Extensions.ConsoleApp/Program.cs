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
            var res = founder.Encrypt("myKey");
            var decres = res.Decrypt("myKey");
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
