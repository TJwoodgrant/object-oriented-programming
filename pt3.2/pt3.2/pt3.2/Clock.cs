using System;
using System.Collections.Generic;
using System.Text;

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


    }
}
