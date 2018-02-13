using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeSimpleApplication.Core.Ports;
using SomeSimpleApplication.Core.Types;

namespace SomeSimpleApplication.Tests
{
    public class InMemoryPersonStorage : IPersonDataPort
    {
        private int _counter = 0;
        private readonly Dictionary<int, Person> _personsStorage = new Dictionary<int, Person>();

        public int Save(Person person)
        {
            if (person.Id == 0)
            {
                _counter++;

                _personsStorage.Add(_counter, person);

                return _counter;
            }
            else if (_personsStorage.ContainsKey(person.Id))
            {
                _personsStorage[person.Id] = person;
                return person.Id;
            }

            return 0;
        }

        public Person Load(int id)
        {
            if (_personsStorage.ContainsKey(id))
            {
                Person p = _personsStorage[id];
                return new Person {FirstName = p.FirstName, LastName = p.LastName, Id = p.Id};
            }

            return null;
        }

        public void Delete(int id)
        {
            if (_personsStorage.ContainsKey(id))
            {
                _personsStorage.Remove(id);
            }

        }
    }
}
