using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class CommandProcessor : Command
    {
        

        public CommandProcessor()
            : base(new string[] { "command" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            Command c;
            switch (text[0].ToLower())
            {
                case "look":
                    c = new Look();
                    break;
                case "stare":
                    c = new Look();
                    break;
                case "inspect":
                    c = new Look();
                    break;
                case "examine":
                    c = new Look();
                    break;
                case "eye":
                    c = new Look();
                    break;
                case "move":
                    c = new Move();
                    break;
                case "head":
                    c = new Move();
                    break;
                case "go":
                    c = new Move();
                    break;
                case "leave":
                    c = new Move();
                    break;
                case "take":
                    c = new Take();
                    break;
                default:
                    c = new Look();
                    break;
            }

            return c.Execute(p, text);
        }
    }
}
