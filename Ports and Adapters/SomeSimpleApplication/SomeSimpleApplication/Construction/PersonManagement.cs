using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeSimpleApplication.Core;
using SomeSimpleApplication.Core.Ports;
using Unity;

namespace SomeSimpleApplication.Construction
{
    /// <summary>
    /// Diese Klasse steuert die Zusammenstellung aller Komponenten
    /// </summary> 
    public class PersonManagement
    {
        private UnityContainer _unityContainer = null;
        private readonly IConstructionStrategy _constructionStrategy;
        
        public PersonManagement()
        {
            _constructionStrategy = new DefaultConstructionStrategy();
        }

        public PersonManagement(IConstructionStrategy constructionStrategy)
        {
            _constructionStrategy = constructionStrategy;
        }

        private void Construct()
        {
            // Erstellen des DependencyContainers
            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType(typeof(IPersonDataPort), _constructionStrategy.PersonDataPortType);
            _unityContainer.RegisterType(typeof(IPersons), typeof(Persons));
        }

        /// <summary>
        /// Ermittelt die Instanz eines Dienstes
        /// </summary>
        public T GetService<T>()
        {
            if (_unityContainer == null)
            {
                Construct();
            }

            T service = _unityContainer.Resolve<T>();

            return service;
        }
    }
}
