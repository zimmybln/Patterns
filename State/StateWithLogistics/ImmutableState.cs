using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace StateWithLogistics
{
    public record CustomState
    {
        public int FirstValue { get; set; }
        public string Name { get; set; }
    }

    [TestFixture]
    public class ImmutableState
    {
        [Test]
        public void CreateChangedStateCopy()
        {
            CustomState state = new CustomState() { FirstValue = 20, Name = "Paul" };

            var state2 = state with { FirstValue = 30 };

            Assert.AreEqual(20, state.FirstValue);
            Assert.AreEqual("Paul", state2.Name);
        }
    }
}
