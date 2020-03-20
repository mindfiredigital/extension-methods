using Extension.Methods;
using System;
using System.Collections.Generic;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C#Extension Methods".Encrypt("myEncryptionKey"));
            Console.ReadKey();
        }
    }
}
