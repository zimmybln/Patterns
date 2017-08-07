using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.Exceptions
{
    public class UnknownStateException : Exception
    {
        public UnknownStateException(string name) :
            base($"The state {name} is unknown")
        {
            Name = name;
        }

        public string Name { get; }
    }
}
