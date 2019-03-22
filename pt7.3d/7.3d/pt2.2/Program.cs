using System;

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

        public static void WriteColoredLine(string message, ConsoleColor color)
        {
            WriteColored(message, color);
            Console.WriteLine();
        }


        public static void WriteColored(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = originalColor;
        }

        public static void ColoredConsoleWrite(ConsoleColor color, string text) // Turn this into an extension class.
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            
            Console.ForegroundColor = originalColor;
        }

        public static void WriteColored(string[] messages, ConsoleColor[] colors)
        {

            if (messages.Length != colors.Length)
                throw new InvalidOperationException("Arrays of string and color must be of length to match!");

            for (int i = 0; i < messages.Length; i++)
            {
                WriteColored(messages[i], colors[i]);
            }
            
        }

        public static void WriteColoredLine(string[] messages, ConsoleColor[] colors)
        {
            WriteColored(messages, colors);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            string _input;
            ConsoleColor _sysCol = ConsoleColor.DarkGray;
            ConsoleColor _norCol = ConsoleColor.Gray;
            ConsoleColor _txtCol = ConsoleColor.Cyan;
            ConsoleColor _redCol = ConsoleColor.DarkRed;

            Bag bag = new Bag(new string[] { "bag"}, "cloth", "A small cloth bag endorned with a 6-petal star atop a circle. Funnily enough, you don't recognise it.");

            Item redPot = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion.");
            Item Gem = new Item(new string[] { "gem" }, "phosphophyllite", "An emerald-green gem of about three-and-a-half hardness. Pretty.");
            Item Ring = new Item(new string[] { "ring" }, "Maia's", "A toy ring made for children covered with a specks of dirt. You don't recognise the ring... yet you know it belongs to someone special, but who?");
            Item woodblade = new Item(new string[] { "blade" }, "wooden", "A mighty-fine wooden training sword. Beware of termites.");
            Item teaTable = new Item(new string[] { "table" }, "tea", "A tea table lined with an odd antique tablecloth with seemingly infinite supplies of tea and sweets. " +
                "Four chairs surround the table at each edge. Centre-table is a vase of more blood-red roses, the sight of which seems mesmerising. ");
            Location teaRoom = new Location("Fancy Tea Room", "You're in a fancy room decorated with odd colours of an antique design. Definitely not to your liking. " +
                "There are sweets and tea on the table of seemingly infinite supply; a large door overtaken by roses dominates the wall to your right. " +
                "\r\nA dizzying sweet scent starts to fills the room, your gut tells you it's a bad omen. After all, the scent is coming from the blood-red roses. ");

            Location intricateRoom = new Location("Intricate Room", "Another fancy room with decorated in an odd colours of antiquity. " +
                "A magnificent window dominates the wall in front of you, letting in nothing but darkness. Through the bright " +
                "reflections in the window you can make out a dark, dense, forest.");

            Location apartmentRoom = new Location("Apartment", "Clearly a well-lit student apartment-room, yet, you can't help but feel that " +
                "this room is eeriely familiar. \r\n" +
                "A large bed sized for two takes up most of the living space in the middle with some smaller pieces of furniture spaced evenly throughout the room. ");

            Path teaToIntricate = new Path(new string[] { "north" }, "Fancy Door", "A foreboding doorway with intricate rose carvings.", teaRoom, intricateRoom);
            Path intricateToTea = new Path(new string[] { "south" }, "Fancy Door", "A foreboding doorway with intricate rose carvings.", intricateRoom, teaRoom);
            Path teaToApart = new Path(new string[] { "east" }, "Scary Door... Gate.", "A rose-laidened door bursting to the seam in great red colours. It gives off quite an ominous feeling.", teaRoom, apartmentRoom);
            Path apartToTea = new Path(new string[] { "south" }, "Scary Door... Gate.", "A rose-laidened door bursting to the seam in great red colours. It gives off quite an ominous feeling.", apartmentRoom, teaRoom);

            teaRoom.AddPath(teaToIntricate);
            teaRoom.AddPath(teaToApart);
            intricateRoom.AddPath(intricateToTea);
            apartmentRoom.AddPath(apartToTea);

            teaRoom.Inventory.Put(teaTable);
            intricateRoom.Inventory.Put(Ring);


            Console.WriteLine();

            WriteColoredLine(new string[]
                {
                    "Welcome to ",
                    "Nightmaher!"
                }, new ConsoleColor[] {
                    _norCol,
                    _redCol
                }
            );

            WriteColoredLine("The story of one's eternal rest.", _sysCol);
            Console.WriteLine();

            Console.WriteLine("This is version 0.6.1 'Nightmare-themed Maze. Happy. Hapy.' | Iteration 7 in progress ");
            Console.WriteLine();
            Console.WriteLine("What is your name?");
            Console.ForegroundColor = _txtCol;
            string name = Console.ReadLine();
            Console.ForegroundColor = _norCol;
            Console.WriteLine("How would you describe yourself? (e.g. 'A mighty programmer')");
            Console.ForegroundColor = _txtCol;
            string description = Console.ReadLine() + "!";
            Console.ForegroundColor = _norCol;
            
            Console.WriteLine();
            WriteColoredLine((name + ", " + description + " It is time to leave the lecture and fall into the world of nightmahers!"),_txtCol);
            Console.WriteLine();

            Player player = new Player(name, description);

            

            player.Location = teaRoom;

            player.Inventory.Put(redPot);
            bag.Inventory.Put(Gem);
            player.Inventory.Put(bag);
            bag.Inventory.Put(woodblade);

            Command c = new CommandProcessor();

            Console.WriteLine();
            WriteColoredLine(new string[] { "    ------- ", "Chapter 1", " --------    \r\n" },
            new ConsoleColor[] {_sysCol, ConsoleColor.Yellow, _sysCol});

            WriteColoredLine("You wake up, feeling dizzy. \r\nYou don't know where you are or why you're here.", _sysCol);
            Console.WriteLine();
            WriteColoredLine(c.Execute(player, new string[] { "look" }), _txtCol);


            Console.ForegroundColor = _sysCol;

            while (true)
            {
                Console.ForegroundColor = _sysCol;
                Console.Write("Command--> ");
                Console.ForegroundColor = _norCol;

                _input = Console.ReadLine();
                Console.WriteLine();
                WriteColoredLine(c.Execute(player,_input.Split()), _txtCol);
            }
        }


    }
}
