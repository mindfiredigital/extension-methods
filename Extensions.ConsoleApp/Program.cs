using System;
using System.Linq;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /** Remove sample **/
            var user = new TestUser(1, "Swagat", 12);
            Console.WriteLine(user.ToJson());
            Console.ReadKey();
        }
    }
}
