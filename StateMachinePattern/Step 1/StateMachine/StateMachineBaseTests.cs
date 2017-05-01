using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StateMachine
{
    [TestFixture]
    public class StateMachineBaseTests
    {
        [Test]
        public void AddAState()
        {
            const string statename = "a simple state";

            var statemachine = new StateMachine();

            statemachine.States.Add(new State(statename));

            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.Any(s => s.Name.Equals(statename)));
        }
    }
}
