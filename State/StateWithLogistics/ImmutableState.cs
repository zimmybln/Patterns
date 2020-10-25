//using System;
//using System.Collections.Generic;
//using System.Text;
//using NUnit.Framework;

//namespace StateWithLogistics
//{
//    public record CustomState
//    {
//        public int FirstValue { get; init; }
//        public string Name { get; set; }
//    }

//    public class MyClassWithRecordAsState
//    {
//        public CustomState state { get; init; }

//        public MyClassWithRecordAsState()
//        {
//            state = new CustomState() { FirstValue = 10 };
//        }

//        public void Test()
//        {
//            state = state with { FirstValue = 1 };
//        }



//    }


//    [TestFixture]
//    public class ImmutableState
//    {
//        [Test]
//        public void CreateChangedStateCopy()
//        {
//            CustomState state = new CustomState() { FirstValue = 20, Name = "Paul" };

//            var state2 = state with { FirstValue = 30 };

//            Assert.AreEqual(20, state.FirstValue);
//            Assert.AreEqual("Paul", state2.Name);
//            Assert.AreEqual(30, state2.FirstValue);
//        }
//    }
//}
