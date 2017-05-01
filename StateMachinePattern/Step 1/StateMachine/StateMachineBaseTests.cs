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

            statemachine.States.Add(statename);
            
            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.ContainsByName(statename));
        }

        [Test]
        public void AddAStateWithExpression()
        {
            const string statename = "a simple state";

            var statemachine = new StateMachine();

            State state = new State(statename, () => true);
            
            statemachine.States.Add(statename);

            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.ContainsByName(statename));
        }

        [Test]
        public void AddAStateWithExpressionAndCheck()
        {
            const string statename = "a simple state";

            var statemachine = new StateMachine();

            State state = new State(statename, () => true);

            statemachine.States.Add(state);
            
            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.ContainsByName(statename));
            Assert.IsTrue(statemachine.IsSet(statename));

        }
    }
}
