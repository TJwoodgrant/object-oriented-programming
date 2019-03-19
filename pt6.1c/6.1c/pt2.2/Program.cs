﻿using System;

/**
 * Program.cs, the main entry point for the SwinGame Adventure iteration task
 *  Yes, this solution is named Pt.2.2, that was a lack of foresight on my part.  
 * 
 *  @author Trac J. Better and preferably known as Mikanwolfe.
 *  ID: 101624964
 *  Swinburne University of Technology 2019HS1
 *  
 *  Contact: support@nekox.net
 *   the author is lonely and just got a new keyboard so he wanted to 
 *   do a lot of typing for some unknown reason.
 *   
 *  GitHub: github.com/mikanwolfe
 *  
 *  This is solution Pt6.1c, iterations 5+6
 * 
 */

namespace pt2._2
{
    class Program
    {

        public static void ColoredConsoleWrite(ConsoleColor color, string text) // Turn this into an extension class.
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = originalColor;
        }

        static void Main(string[] args)
        {

            Console.WriteLine();

            Console.Write("Welcome to ");
            ColoredConsoleWrite(ConsoleColor.Red, "Nightmaher");
            Console.WriteLine(".");

            Console.WriteLine();
            ColoredConsoleWrite(ConsoleColor.DarkGray, "   yes, there are a lot of obscure references.");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("This is version 0.5.1 'Nightmare-themed Maze. Happy. Hapy.' | Iteration 6 in Progress. ");
            Console.WriteLine();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("How would you describe yourself? (e.g. 'A mighty programmer')");
            string description = Console.ReadLine() + "!";
            Console.WriteLine();
            Console.WriteLine(name + ", " + description + " It is time to leave the lecture and dive into the land of Disbo-- SwinAdventure!");
            Console.WriteLine();

            Player player = new Player(name, description);

            Bag bag = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag endorned with a 6-petal star atop a circle.");

            Item redPot = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion.");
            Item Gem = new Item(new string[] { "gem" }, "phosphophyllite", "An emerald-green gem of about three-and-a-half hardness. Pretty.");
            Item woodblade = new Item(new string[] { "blade" }, "wooden", "A mighty-fine wooden training sword. Beware of termites.");
            Item teaTable = new Item(new string[] { "table" }, "tea", "A tea table lined with an odd antique tablecloth with seemingly infinite supplies of tea and sweets. " +
                "Four chairs surround the table at each edge. Centre-table is a vase of more blood-red roses, the sight of which seems mesmerising. ");
            Location teaRoom = new Location("Fancy Tea Room", "A fancy room decorated with odd colours of an antique design. Definitely not to your liking. " +
                "There are sweets and tea on the table of seemingly infinite supply; a large door overtaken by roses dominates the wall to your right. " +
                "\r\nA dizzying sweet scent starts to fills the room, your gut tells you it's a bad omen. After all, the scent is coming from the blood-red roses. ");

            teaRoom.Inventory.Put(teaTable);

            player.Location = teaRoom;

            player.Inventory.Put(redPot);
            player.Inventory.Put(Gem);
            player.Inventory.Put(bag);
            bag.Inventory.Put(woodblade);

            while (true)
            {
                Command l = new Look();
                Console.WriteLine();
                Console.Write("Command--> ");
                Console.WriteLine(l.Execute(player, Console.ReadLine().Split()));
                Console.WriteLine();
            }
        }


    }
}
