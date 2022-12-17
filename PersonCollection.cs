using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace PersonTest
{
    public class PersonCollection 
    {
        IPersonComparable _personComparable;
        private List<IPerson> _personCollection;
        private static readonly object lockObject = new object();
        private event Action<IPerson> PersonsCollectionChanged;
       
        public PersonCollection(IPersonComparable personComparable)
        {
            _personComparable = personComparable;
            _personCollection = new List<IPerson>();
        }
        public List<IPerson> getPersonCollection()
        {
            return _personCollection;
        }
        
        public void Add(IPerson person)
        {
            lock (lockObject)
            {
                if (!_personCollection.Any())
                {
                    _personCollection.Add(person);
                }
                else
                {
                    InsertPersonInPlace(person);
                }
                PublishOnChangeCollection(person);
            }
        }

        private void PublishOnChangeCollection(IPerson person)
        {
            if (PersonsCollectionChanged != null)
                PersonsCollectionChanged(person);
        }

        private void InsertPersonInPlace(IPerson person)
        {
            foreach (IPerson personToCompare in _personCollection)
            {
                if (_personComparable.comparePerson(person, personToCompare) == 1)
                {
                    int index = _personCollection.IndexOf(personToCompare);
                    _personCollection.Insert(index, person);
                    return;
                }
            }
            _personCollection.Add(person);
        }

        public void RemoveMax()
        {
            IPerson person = null;
            try
            {
                lock (lockObject)
                {
                    person = _personCollection[0];
                    _personCollection.RemoveAt(0);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            PublishOnChangeCollection(person);
        }

        public void SubscribeToPersonCollection(Action<IPerson> subscriber)
        {
            lock(lockObject)
            {
                PersonsCollectionChanged += subscriber;
            }
        }

        public void UnSubscribeToPersonCollection(Action<IPerson> subscriber)
        {
            lock (lockObject)
            {
                PersonsCollectionChanged -= subscriber;
            }
        }
    }
}
