using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTest
{
    public class Person : IPerson
    {
        public DateTime DateOfBirth { get; }
        public string FirstName { get; }
        public int Height { get; }
        public int id { get; } 
        public string LastName { get; }

        public Person(string FirstName, string lastName, int id)
        {
            this.FirstName = FirstName;
            this.LastName = lastName;
            this.id = id;
        }

    }
}
