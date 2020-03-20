using Extension.Methods;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Color color = "ffffcc88".ToColor();
            var bar = color.R;
            Console.ReadKey();
        }
    }
}
