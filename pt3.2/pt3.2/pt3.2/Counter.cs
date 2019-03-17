using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt3._2
{
    public class Counter
    {
        private int _count;

        public Counter()
        {
            Count = 0;
        }

        public int Count { get => _count; set => _count = value; }

        public void Increment()
        {
            Count++;
        }

        public void Reset()
        {
            Count = 0;
        }

       

    }

    [TestFixture]
    public class TestCounter
    {
        Counter c;

        [Test]
        public void TestCounterCreation()
        {
            c = new Counter();

            Assert.AreEqual(0, c.Count, "TestCounterCreation Counter should be 0 at startup");
        }

        [Test]
        public void TestCounterIncrement()
        {
            c = new Counter();
            c.Increment();

            Assert.AreEqual(1, c.Count, "TestCounterIncrement Counter should be 1 after increment");
        }

        [Test]
        public void TestCounterReset()
        {
            c = new Counter();
            c.Increment();
            c.Reset();

            Assert.AreEqual(0, c.Count, "TestCounterReset Counter should be 0 after reset");
        }

    }

}
