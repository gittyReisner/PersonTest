using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTest
{
    public class SubscriberClass : ISubscriber
    {
        public void SubscriberMethod(IPerson obj)
        {
            Console.WriteLine(obj.FirstName + " was Added/Removed!!");
        }
    }
}
