using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PersonCls
    {
        public PersonCls(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; init; }
        public int Age { get; init; }

      
    }
}
