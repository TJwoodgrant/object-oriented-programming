using System;
using System.Collections.Generic;
using System.Text;

namespace Nightmaher.Core
{
    public class CommandProcessor : Command
    {

        List<Command> _commands;

        public CommandProcessor()
            : base(new string[] { "commandprocessor" })
        {
            _commands = new List<Command>();
            _commands.Add(new Look());
            _commands.Add(new Move());
            _commands.Add(new Take());
            _commands.Add(new Put());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command c in _commands)
            {
                if (c.AreYou(text[0].ToLower()))
                    return c.Execute(p, text);
            }
            return "Error in Command input";
        }
    }
}
