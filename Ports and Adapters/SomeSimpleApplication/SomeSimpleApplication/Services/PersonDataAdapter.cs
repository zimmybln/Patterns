using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeSimpleApplication.Core.Ports;
using SomeSimpleApplication.Core.Types;

namespace SomeSimpleApplication.Services
{
    public class PersonDataAdapter : IPersonDataPort
    {
        public int Save(Person person)
        {
            return 0;
        }

        public Person Load(int id)
        {
            return new Person();
        }

        public void Delete(int id)
        {
            
        }
    }
}
