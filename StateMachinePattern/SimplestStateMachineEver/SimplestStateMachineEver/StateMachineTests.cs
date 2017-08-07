using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimplestStateMachineEver
{
    [TestFixture]
    public class StateMachineTests
    {
        [Test]
        public void CreateWithDefaultState()
        {
            var statemachine = new StateMachine<TestStates>(TestStates.Open);

            Assert.IsTrue(statemachine.State == TestStates.Open);
        }

        [Test]
        public void SetState()
        {
            var statemachine = new StateMachine<TestStates>(TestStates.Open);

            statemachine.SetState(TestStates.Closed);

            Assert.IsTrue(statemachine.State == TestStates.Closed);
        }
    }

    public enum TestStates
    {
        Open,
        Closed
    }
}
