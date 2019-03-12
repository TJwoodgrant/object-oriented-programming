using System;
using System.Collections.Generic;
using System.Text;

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
}
