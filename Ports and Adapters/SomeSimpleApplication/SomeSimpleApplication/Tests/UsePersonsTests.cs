using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeSimpleApplication.Construction;
using SomeSimpleApplication.Core;
using SomeSimpleApplication.Core.Ports;
using SomeSimpleApplication.Core.Types;
using Xunit;

namespace SomeSimpleApplication.Tests
{
    public class UsePersonsTests
    {
        [Fact]
        public void TryToCreatePerson()
        {
            // Erstellen der Datenbank
            IPersonDataPort dataPort = new InMemoryPersonStorage();

            IPersons persons = new Persons(dataPort);

            Person p = persons.Create("Martina", "Mustermann");

            Assert.NotNull(p);
            Assert.True(p.Id > 0);
        }

        [Fact]
        public void TryToUpdatePerson()
        {
            // Erstellen der Datenbank
            IPersonDataPort dataPort = new InMemoryPersonStorage();

            IPersons persons = new Persons(dataPort);

            // Erstellen einer Person
            Person p = persons.Create("Martina", "Mustermann");
            int id = p.Id;
            
            // Aktualisieren der Person
            Person martina = persons.Load(id);

            martina.LastName = "Beispielmann";

            persons.Save(martina);

            // Wieder laden und überprüfen
            Person person3 = persons.Load(id);

            Assert.Equal("Beispielmann", person3.LastName);
        }

        [Fact]
        public void TryToCreatePersonWithConstruction()
        {
            PersonManagement personManagement = new PersonManagement(new TestConstructionStrategy());

            IPersons persons = personManagement.GetService<IPersons>();

            Person p = persons.Create("Martina", "Mustermann");

            Assert.NotNull(p);
            Assert.True(p.Id > 0);
        }

        [Fact]
        public void TryToUpdatePersonWithConstruction()
        {
            PersonManagement personManagement = new PersonManagement(new TestConstructionStrategy());
            
            IPersons persons = personManagement.GetService<IPersons>();

            // Erstellen einer Person
            Person p = persons.Create("Martina", "Mustermann");
            int id = p.Id;

            // Aktualisieren der Person
            Person martina = persons.Load(id);

            martina.LastName = "Beispielmann";

            persons.Save(martina);

            // Wieder laden und überprüfen
            Person person3 = persons.Load(id);

            Assert.Equal("Beispielmann", person3.LastName);
        }


        class TestConstructionStrategy : IConstructionStrategy
        {
            public Type PersonDataPortType => typeof(InMemoryPersonStorage);
        }

    }
}
