using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt3._2
{
    class Clock
    {
        List<Counter> _counters;

        public Clock()
        {
               
            _counters = new List<Counter>();
            for(int i = 0; i < 3; i++)
            {
                _counters.Add(new Counter());
            }
                
        }

        public void Tick()
        {
            _counters[0].Increment();

            if (_counters[0].Count >= 60)
            {
                _counters[0].Reset();
                _counters[1].Increment();
            }
            if (_counters[1].Count >= 60)
            {
                _counters[1].Reset();
                _counters[2].Increment();
            }
            if (_counters[2].Count >= 24)
            {
                _counters[2].Reset();
            }
        }

        public void PrintTime()
        {
            Console.WriteLine(_counters[2].Count.ToString("00") + ":" + _counters[1].Count.ToString("00") + ":" + _counters[0].Count.ToString("00"));
        }

        public string Time
        {
            get => (_counters[2].Count.ToString("00") + ":" + _counters[1].Count.ToString("00") + ":" + _counters[0].Count.ToString("00"));
        }


    }

    [TestFixture]
    class TestClock
    {
        Clock c;

        [Test]
        public void TestClockCreation()
        {
            c = new Clock();
            string expected = "00:00:00";

            Assert.AreEqual(expected, c.Time, "Test clock starting time, should be 00:00:00 at new clock");

        }

        [Test]
        public void TestClockTick()
        {
            c = new Clock();
            c.Tick();
            string expected = "00:00:01";

            Assert.AreEqual(expected, c.Time, "Test Clock tick, should be 00:00:01 after one tick");

        }

        [Test]
        public void TestClockRolloverMinutes()
        {
            c = new Clock();
            for (int i = 0; i < 60; i++)
            {
                c.Tick();
            }
            string expected = "00:01:00";

            Assert.AreEqual(expected, c.Time, "Test clock at-minute rollover, should be 00:01:00, not 00:00:60");
        }

        [Test]
        public void TestClockRolloverHour()
        {
            c = new Clock();
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    c.Tick();
                }
            }
            string expected = "01:00:00";

            Assert.AreEqual(expected, c.Time, "Test clock at-hour rollover, should be 01:00:00, not 00:60:00");
        }

        [Test]
        public void TestClockRolloverDay()
        {
            c = new Clock();
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    for (int k = 0; k < 60; k++)
                    {
                        c.Tick();
                    }
                }
            }
            string expected = "00:00:00";

            Assert.AreEqual(expected, c.Time, "Test clock at-day rollover, should be 00:00:00, not 24:00:00");
        }

    }
}
