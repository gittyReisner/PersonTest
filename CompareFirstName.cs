using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTest
{
    public class CompareFirstName : IPersonComparable
    {
        public int comparePerson(IPerson personA, IPerson personB)
        {
           return personA.FirstName.CompareTo(personB.FirstName);
        }
    }
}
