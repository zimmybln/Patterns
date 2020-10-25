using System;
using NUnit.Framework;

namespace StateWithLogistics
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var context = new SampleContext();

            for (int i = 90; i <= 200; i += 10)
            {
                context.EmergencyValue = i;

                Console.WriteLine(context.EmergencyValue);
                context.DoSomething();

            }

        }
    }
}