using System;

namespace pt1._3
{
    class MainClass
    {

        static void PrintCounters(Counter[] counters)
        {
            Counter c;

            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name,c.Value);
            }
        }

    static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
