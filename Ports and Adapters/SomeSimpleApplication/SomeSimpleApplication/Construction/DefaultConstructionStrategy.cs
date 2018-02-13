using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeSimpleApplication.Services;

namespace SomeSimpleApplication.Construction
{
    /// <summary>
    /// Standardimplementierung der Zusammenstellung der Komponenten
    /// für das Personenmanagement
    /// </summary>
    internal class DefaultConstructionStrategy : IConstructionStrategy
    {
        public Type PersonDataPortType => typeof(PersonDataAdapter);
        
    }
}
