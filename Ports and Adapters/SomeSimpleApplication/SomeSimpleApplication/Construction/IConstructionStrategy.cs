using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Registration;

namespace SomeSimpleApplication.Construction
{
    /// <summary>
    /// Diese Schnittstelle definiert die Konstruktion 
    /// des Personenmanagements
    /// </summary>
    public interface IConstructionStrategy
    {
        /// <summary>
        /// Liefert den Typ, der die Storage-Schnittstelle implementiert
        /// </summary>
        Type PersonDataPortType { get; }
    }
}
