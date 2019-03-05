using System;

namespace helloworld
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Message myMessage;
            Message[] messages = new Message[5];
            string name;

            myMessage = new Message("Hello World...");
            myMessage.Print();

           
            messages[0] = new Message("if you're seeing this then the author forgot to impleme--");
            messages[1] = new Message("probably will try for a credit again");
            messages[2] = new Message("probably knows more about programming than you think");
            messages[3] = new Message("Requires elevated permissions! Run program as sudo to continue!");

            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();

            if (name.ToLower() == "jimmy")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "danny")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "klim")
            {
                messages[2].Print();
            }
            else
            {
                messages[3].Print();
            }




            Console.ReadLine();
        }
    }
}
