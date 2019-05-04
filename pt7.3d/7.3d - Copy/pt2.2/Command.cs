using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) :
            base(ids)
        {

        }

        public abstract string Execute(Player p, string[] text);

    }
}
