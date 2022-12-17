using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IPerson personDan = new Person("Dan", "Haim", 300881224);
            IPerson personBarak = new Person("Israel", "Israeli", 123456789);
            IPerson personZ = new Person("Gandalf", "wizard", 666);
            IPerson personA = new Person("Frudo", "baggins", 600);
            IPersonComparable NameCompare = new CompareFirstName(); //CompareId();
            PersonCollection PersonCollection = new PersonCollection(NameCompare);
            PersonCollection.SubscribeToPersonCollection(new SubscriberClass().SubscriberMethod);

            PersonCollection.Add(personDan);
            PersonCollection.Add(personBarak);
            PersonCollection.Add(personZ);
            PersonCollection.Add(personA);

            printCollection(PersonCollection);

            PersonCollection.RemoveMax();
            printCollection(PersonCollection);

            PersonCollection.RemoveMax();
            printCollection(PersonCollection);

        }

        private static void printCollection(PersonCollection PersonCollection)
        {
            Console.WriteLine("=====================\nThe current collection:");
            foreach (IPerson person in PersonCollection.getPersonCollection())
            {
                Console.WriteLine(person.FirstName);
            }
            Console.WriteLine("=====================");
        }
    }
}
