using System;
using System.Collections.Generic;

namespace ExampleProgram
{
    class Program
    {

       


        static void Main(string[] args)
        {
            List<string> ident = new List<string>();

            ident.Add("test");
            ident.Add("one");

            foreach( string s in ident)
            {
                Console.WriteLine(s);
            }




            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
