using NUnit.Framework;

namespace StateMachine.VariationOne
{
    [TestFixture]
    public class StateMachineBaseTests
    {
        [Test]
        public void AddAState()
        {
            const string statename = "a simple state";

            var statemachine = new VariationOne.StateMachine();

            statemachine.States.Add(statename);
            
            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.ContainsByName(statename));
        }

        [Test]
        public void AddAStateWithExpression()
        {
            const string statename = "a simple state";

            var statemachine = new VariationOne.StateMachine();

            State state = new State(statename, () => true);
            
            statemachine.States.Add(statename);

            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.ContainsByName(statename));
        }

        [Test]
        public void AddAStateWithExpressionAndCheck()
        {
            const string statename = "a simple state";

            var statemachine = new VariationOne.StateMachine();

            State state = new State(statename, () => true);

            statemachine.States.Add(state);
            
            Assert.IsTrue(statemachine.States.Count == 1);
            Assert.IsTrue(statemachine.States.ContainsByName(statename));
            Assert.IsTrue(statemachine.IsSet(statename));

        }
    }
}
