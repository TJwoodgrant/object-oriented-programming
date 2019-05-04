﻿using System;

//author mikanwolfe

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
            bool NotRequestClose = true;
            ConsoleColor _sysCol = ConsoleColor.DarkGray;
            ConsoleColor _norCol = ConsoleColor.Gray;
            ConsoleColor _txtCol = ConsoleColor.Cyan;
            ConsoleColor _redCol = ConsoleColor.DarkRed;


            Bag bag = new Bag(new string[] { "bag"}, "cloth", "A small cloth bag adnorned with a 6-petal star atop a circle. Funnily enough, you don't recognise it.");

            Item redPot = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion with an odd label, presumably a manufacturer: 'audacity'.");
            Item Gem = new Item(new string[] { "gem" }, "phosphophyllite", "An emerald-green gem of about three-and-a-half hardness. Pretty. The gem urges you to find the name of the girl.\r\nHer surname is Naito, \r\n First name?");
            Item Ring = new Item(new string[] { "ring" }, "Maia's", "A toy ring made for children covered with a specks of dirt. You don't recognise the ring... yet you know it belongs to 'Maia', maybe it's a clue.");
            Item woodblade = new Item(new string[] { "blade" }, "wooden", "A mighty-fine wooden training sword, there's some writing on it too: \r\n\n 'a spectrogram is the final clue'.");
            Item sweets = new Item(new string[] { "sweet" }, "colourful", "A sweet wrapped in a colourful wrapper with thorny rose prints on it. Enthusiastically, the supplier's website sprawled across the wrapper: nekox.net!!!");
            Item paper = new Item(new string[] { "note" }, "worn", "A worn out piece of paper with some writing on it. It seems to be a puzzle of some sort, written on it: \r\n\n  ' the password is h X X X m a h e r'");
            Item rose = new Item(new string[] { "rose" }, "rose-red", "A blood-red night-maher without the thorns. Despite the mesmerising scent, the rose seems to put words in place: \r\n\n let's have a-a-a-*happy nightmare*");
            Item nightmareRose = new Item(new string[] { "nightmare" }, "rose-red", "A blood-red rose without the thorns. Despite the mesmerising scent, the rose seems to put words in place: \r\n\n    /files/{password}.png");
            Item card = new Item(new string[] { "card" }, "worn", "A piece of yellowed-out card with folds, rips, and tears. The whole lot. It reads:" +
                "\r\n\n     'You've lost something. It isn't just here, but also outside the black box.'");
            Item laptop = new Item(new string[] { "laptop" }, "sleek", "A sleek and stylish laptop with a surprisingly clicky keyboard. A familiar star-atop-circle logo paints the back cover with scratched out words that are hard to make out. It seems to read " +
                "'NekoXmimi Cooperative'.\r\n\nAfter taking a while to boot, it opens to a login screen with the user 'nekox.net', it requires a password.");

            Bag bed = new Bag(new string[] { "bed" }, "big", "A bigger-than-life bed sits in the middle of this apartment room. Literally in the middle: everything else seemingly surrounds the bed. " +
                "The bed seems awfully large for a single apartment room, as if it were made for two. Some text is sprawled across the sheet: \r\n\n 'X a X X m a h e r'",false);
            Bag teaTable = new Bag(new string[] { "table" }, "tea", "A tea table lined with an odd antique tablecloth with seemingly infinite supplies of tea and sweets. " +
                "Four chairs surround the table at each edge. Centre-table is a vase of more blood-red roses, the sight of which seems mesmerising. Some writing is sprawled across the edge:\r\n\nX X p X m a h e r",false);
            Location teaRoom = new Location("Fancy Tea Room", "You're in a fancy room decorated with odd colours of an antique design. Definitely not to your liking. " +
                "There are sweets and tea on the table of seemingly infinite supply; a large door overtaken by roses dominates the wall to your right. " +
                "\r\nA dizzying sweet scent starts to fills the room, your gut tells you it's a bad omen. After all, the scent is coming from the blood-red roses. ");

            Location intricateRoom = new Location("Intricate Room", "Another fancy room with decorated in an odd colours of antiquity. " +
                "A magnificent window dominates the wall in front of you, letting in nothing but darkness. Through the bright " +
                "reflections in the window you can make out a dark, dense, forest.");

            Location apartmentRoom = new Location("Apartment", "Clearly a well-lit student apartment-room, yet, you can't help but feel that " +
                "this room is eeriely familiar, as if you'd waken up from a bad dream.\r\n" +
                "A large bed sized for two takes up most of the living space in the middle with some smaller pieces of furniture spaced evenly throughout the room. ");

            Location forestRoom = new Location("Murky Forest", "A deep, dark, unrelenting forest.\r\n\n Why can't you leave?\r\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            Location trainStation = new Location("Train Station", "The bright sun contrasts with the space you just arrived from. Signs litter the station in Japanese characters, though the sky-rise paths" +
                " and the modern look of the station grabs your attention. Outside the station, a stand seems to be selling pet cats, as evidenced by the unreasonably large signage with 'neko' written all over. " +
                "A train with bright-blue stripes sits on the tracks awaiting passengers; the train seems to be headed across the bridge above the river. \r\n A large and obstructing sign paints the sky however, urging patrons" +
                "to visit their website for further details. It's hard to make out the site, but it seems to end in a .net URL.");
            Location flowerTrainStation = new Location("Flower-Infested Train Station", "The sun seems to be eternally setting in this flower-infested station. Vines run up and down the station and familiar" +
                " rose-red flowers bloom. As far as the eye can see, the entire area seems to be no more than a static image frozen in time, with compression artefacts to match. Yet, " +
                "fuzzy as it may be, you recognise this location.");

            Path teaToIntricate = new Path(new string[] { "north" }, "Fancy Door", "A foreboding doorway with intricate rose carvings.", teaRoom, intricateRoom);
            Path apartToStation = new Path(new string[] { "down" }, "Front Door", "The front door. It won't lock anyway, so there's no use trying.", apartmentRoom, trainStation);
            Path stationToAPart = new Path(new string[] { "up" }, "Back Home", "The way home. You don't know how you know, but you do know. Know.", trainStation, apartmentRoom);
            Path intricateToTea = new Path(new string[] { "south" }, "Fancy Door", "A foreboding doorway with intricate rose carvings.", intricateRoom, teaRoom);
            Path teaToApart = new Path(new string[] { "east" }, "Scary Door... Gate.", "A rose-laidened door bursting to the seam in great red colours. It gives off quite an ominous feeling.", teaRoom, apartmentRoom);
            Path apartToTea = new Path(new string[] { "south" }, "Scary Door... Gate.", "A rose-laidened door bursting to the seam in great red colours. It gives off quite an ominous feeling.", apartmentRoom, teaRoom);
            Path stationToForest = new Path(new string[] { "west" }, "path you're not familiar with", "You know something is over there, but you can't help but know what it isn't.", trainStation, forestRoom);
            Path forestToIntricate = new Path(new string[] { "down" }, "weird path that seems unnatural", "You know something is over there, but you can't help but know what it isn't.", forestRoom, intricateRoom);

            teaRoom.AddPath(teaToIntricate);
            teaRoom.AddPath(teaToApart);
            intricateRoom.AddPath(intricateToTea);
            apartmentRoom.AddPath(apartToTea);
            apartmentRoom.AddPath(apartToStation);
            trainStation.AddPath(stationToAPart);
            trainStation.AddPath(stationToForest);
            forestRoom.AddPath(forestToIntricate);


            forestRoom.Inventory.Put(nightmareRose);
            teaTable.Inventory.Put(sweets);
            teaTable.Inventory.Put(card);
            bed.Inventory.Put(laptop);
            intricateRoom.Inventory.Put(rose);

            apartmentRoom.Inventory.Put(paper);
            apartmentRoom.Inventory.Put(bed);
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

            Console.WriteLine("This is version 0.6.1 'Nightmare-themed Maze. Happy. Hapy.' | Iteration 9 in progress ");
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
            WriteColoredLine(new string[] { "    ------- ", "Prologue", " --------    \r\n" },
            new ConsoleColor[] {_sysCol, ConsoleColor.Yellow, _sysCol});

            WriteColoredLine("You wake up, feeling dizzy. \r\nThere's something for you to find somewhere.", _sysCol);
            Console.WriteLine();
            WriteColored(c.Execute(player, new string[] { "look" }), _txtCol);


            Console.ForegroundColor = _sysCol;

            while (NotRequestClose)
            {
                Console.ForegroundColor = _sysCol;
                Console.Write("Command--> ");
                Console.ForegroundColor = _norCol;

                _input = Console.ReadLine();
                Console.WriteLine();

                if (_input.Split()[0].ToLower() == "quit")
                {
                    NotRequestClose = false;
                } else
                {
                    WriteColoredLine(c.Execute(player, _input.Split()), _txtCol);
                }
                    
                
            }
        }


    }
}
