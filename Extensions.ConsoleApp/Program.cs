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
            //var obj = new Bar()
            //{
            //    FirstName = "Swagat",
            //    LastName = "Swain",
            //    Age = 29
            //};
            //var jsonString = obj.ToJson();
            //Console.WriteLine(jsonString);


            var jsonString = "{\"FirstName\":\"Swagat\",\"LastName\":\"Swain\",\"Age\":29}";
            //var bar = jsonString.JsonToObject<Bar>();
            var foo = jsonString.JsonToDictionary();
            
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
