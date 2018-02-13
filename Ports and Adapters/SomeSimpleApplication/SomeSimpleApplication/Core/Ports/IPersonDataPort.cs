using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeSimpleApplication.Core.Types;

namespace SomeSimpleApplication.Core.Ports
{
    /// <summary>
    /// Definition des Datenports für die Entität Person
    /// </summary>
    public interface IPersonDataPort
    {
        int Save(Person person);

        Person Load(int id);

        void Delete(int id);
    }
}
