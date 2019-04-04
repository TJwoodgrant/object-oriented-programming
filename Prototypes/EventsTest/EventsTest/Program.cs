using System;

namespace EventsTest
{
    class Program
    {

        public delegate void delegatePrint(int Value);



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            /*
             * Passing functions as parameters: Delegates essentially act as pointers towards 
             *  functions. It's a reference data type that holds the reference of a method.
             *  
             * They can be declared using the *delegate* keyword.
             * 
             * Here's an example.
             * 
             */


            delegatePrint printDel = PrintNumber;

            printDel(1000);

            printDel = PrintMoney;

            printDel(1000);


            Console.ReadLine();


        }


        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0, -12:N0}", num);
        }

        public static void PrintMoney(int num)
        {
            Console.WriteLine("Money: {0:C}", num);
        }

    }
}
