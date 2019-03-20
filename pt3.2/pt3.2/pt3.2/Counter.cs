using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt3._2
{
    public class Counter
    {
        private int _value;
        private string _name;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public int Count { get => _value; }

        

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }

       

    }

    [TestFixture]
    public class TestCounter
    {
        Counter c;

        [Test]
        public void TestCounterCreation()
        {
            c = new Counter("name");

            Assert.AreEqual(0, c.Count, "TestCounterCreation Counter should be 0 at startup");
        }

        [Test]
        public void TestCounterIncrement()
        {
            c = new Counter("name");
            c.Increment();

            Assert.AreEqual(1, c.Count, "TestCounterIncrement Counter should be 1 after increment");
        }

        [Test]
        public void TestCounterReset()
        {
            c = new Counter("name");
            c.Increment();
            c.Reset();

            Assert.AreEqual(0, c.Count, "TestCounterReset Counter should be 0 after reset");
        }

    }

}
