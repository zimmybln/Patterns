using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StateMachineWithCharacteristicByValues
{
    [TestFixture]
    public class StateMachineTests
    {
        [Test]
        public void DefineDefaultState()
        {
            var statemachine = new StateMachine<MyStates, CustomContext>(MyStates.First);
              
            Assert.IsTrue(statemachine.CurrentState == MyStates.First);
        }

        [Test]
        public void AccessState()
        {
            var statemachine = new StateMachine<MyStates, CustomContext>(MyStates.First);

            var state = statemachine[MyStates.Following];

            Assert.IsNotNull(state, "state != null");
            Assert.IsTrue(state == MyStates.Following, "state == MyStates.Closed");
            Assert.IsFalse(state == MyStates.First, "state == MyStates.Open");
        }

        [Test]
        public void AccessStateWithCheck()
        {
            var statemachine = new StateMachine<MyStates, CustomContext>(MyStates.First);

            statemachine[MyStates.Following].OnVerifyState(context => context.IsDone);
            
            CustomContext c = new CustomContext {IsDone = true};

            var changed = statemachine.FindState(c);

            Assert.IsTrue(changed, "changed");
            Assert.IsTrue(statemachine.CurrentState == MyStates.Following);

        }

    }


    public enum MyStates : int
    {
        First,
        Following
    }

    public class CustomContext
    {
        public bool IsDone { get; set; }
    }
}
