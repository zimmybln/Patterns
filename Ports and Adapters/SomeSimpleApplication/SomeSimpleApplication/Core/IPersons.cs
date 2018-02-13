using SomeSimpleApplication.Core.Types;

namespace SomeSimpleApplication.Core
{

    public interface IPersons
    {
        Person Create(string firstName, string lastName);
        Person Load(int id);
        void Save(Person person);
    }
}