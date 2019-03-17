using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    abstract class Command
    {
        public Command(string[] ids)
        {

        }

        public abstract string Execute(Player p, string[] text) ; 
    }
}
