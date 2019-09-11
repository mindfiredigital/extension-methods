using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.ConsoleApp
{
    public class TestUser
    {
        public TestUser()
        {

        }
        public TestUser(int id, string name , int age)
        {
            TestUserId = id;
            Name = name;
            Age = age;
        }
        public int TestUserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
