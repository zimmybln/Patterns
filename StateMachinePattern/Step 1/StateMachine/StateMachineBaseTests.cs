using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StateMachine.Exceptions;

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

        [TestCase(true)]
        [TestCase(false)]
        public void AddAStateWithExpressionAndCheck(bool thecase)
        {
            const string statename = "a simple state";

            var statemachine = new StateMachine();

            State state = new State(statename, () => thecase);

            statemachine.States.Add(state);
            
            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.ContainsByName(statename));
            Assert.IsTrue(statemachine.IsSet(statename) == thecase);
        }

        [Test]
        public void AddAndRemoveAState()
        {
            const string statename = "a simple state";

            var statemachine = new StateMachine();

            State state = new State(statename, () => true);

            statemachine.States.Add(state);
            
            statemachine.States.Remove(state);

            Assert.IsTrue(statemachine.States.Count == 0);
            Assert.IsTrue(!statemachine.States.ContainsByName(statename));
        }

        [Test]
        public void AccessUnknownState()
        {
            const string statename = "a simple state";

            var statemachine = new StateMachine();

            State state = new State(statename, () => true);

            statemachine.States.Add(state);

            Assert.Throws<UnknownStateException>(() => statemachine.IsSet("foo"));
        }
    }
}
