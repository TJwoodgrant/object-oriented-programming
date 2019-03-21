using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class Move : Command
    {
        public Move() :
            base(new string[] { "move" })
        {
            
        }

        public override string Execute(Player p, string[] text)
        {
            string error = "Error in move input.";
            string _moveDir;

            if (text[0].ToLower() != "move")
                return error;

            switch (text.Length)
            {
                case 1:
                    return "Move where?";

                case 2:
                    _moveDir = text[1].ToLower();
                    break;

                case 3:
                    _moveDir = text[2].ToLower();
                    break;

                default:
                    return error;
            }

            GameObject _path = p.Location.Locate(_moveDir);
            if (_path != null)
            {
                if (_path.GetType() != typeof(Path))
                    return "Could not find the " + _path.Name;
                p.Move((Path)_path);
                return "You have moved to the " + ((Path)_path).Destination.Name + "\r\n\n" +
                    ((Path)_path).Destination.LongDescription;
            } else
            {
                return error;
            }

        }

        
    }
}
