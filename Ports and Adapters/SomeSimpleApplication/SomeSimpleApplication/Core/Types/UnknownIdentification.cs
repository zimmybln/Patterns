using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeSimpleApplication.Core.Types
{
    /// <summary>
    /// Signalisiert, dass eine Identifikation nicht aufgelöst werden konnte.
    /// </summary>
    public class UnknownIdentification : Exception
    {
        public UnknownIdentification(int id) 
            : base($"{nameof(UnknownIdentification)}: {id}")
        {
            Id = id;
        }
        
        public int Id { get; private set; }
    }
}
