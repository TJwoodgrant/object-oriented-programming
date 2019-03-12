using System;
using System.Threading;

namespace pt3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock myClock = new Clock();
            Console.WriteLine("Hello World!");

            while (true)
            {
                Thread.Sleep(100);
                Console.Clear();
                myClock.Tick();
                myClock.PrintTime();
            }
        
        }
    }
}
