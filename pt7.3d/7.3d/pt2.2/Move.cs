using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class Move : Command
    {
        public Move() :
            base(new string[] { "look" })
        {
            
        }

        public override string Execute(Player p, string[] text)
        {
            throw new NotImplementedException();
        }
    }
}
