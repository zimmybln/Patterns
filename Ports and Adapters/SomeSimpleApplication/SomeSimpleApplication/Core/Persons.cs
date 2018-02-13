using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeSimpleApplication.Core.Types;
using SomeSimpleApplication.Core.Ports;

namespace SomeSimpleApplication.Core
{
    /// <summary>
    /// Kernfunktionalität für die Entität Person
    /// </summary>
    public class Persons : IPersons
    {
        private readonly IPersonDataPort _personDataPort;

        public Persons(IPersonDataPort dataport)
        {
            _personDataPort = dataport;
        }

        public Person Create(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            Person p = new Person {FirstName = firstName, LastName = lastName, Id = 0};

            p.Id = _personDataPort.Save(p);

            return p;
        }

        public Person Load(int id)
        {
            Person p = _personDataPort.Load(id);

            if (p == null)
            {
                throw new UnknownIdentification(id);
            }

            return p;
        }

        public void Save(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (person.Id == 0)
            {
                throw new UnknownIdentification(0);
            }

            _personDataPort.Save(person);
        }
    }
}
