using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class CommandProcessor : Command
    {
        List<Command> _commands;

        public CommandProcessor()
            : base(new string[] { "command" })
        {
            _commands = new List<Command>();
            _commands.Add(new Look());
            _commands.Add(new Move());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach(Command c in _commands)
            {
                if (c.AreYou(text[0].ToLower()))
                    return c.Execute(p, text);
            }

            return "Error in Command input";
        }
    }
}
