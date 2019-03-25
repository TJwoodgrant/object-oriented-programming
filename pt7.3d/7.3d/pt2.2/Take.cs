using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class Take : Command
    {
        public Take()
            : base(new string[] { "take" })
        {
        }

        bool ContainsString(string searched, string[] value)
        {
            foreach (string s in value)
            {
                if (searched.Contains(s))
                    return true;
            }
            return false;
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container = null;
            string _itemid;
            string error = "Error in take input.";

            switch (text.Length)
            {
                case 1:
                    return "Take what?";

                case 2:
                    if (ContainsString(text[1].ToLower(), new string[] {"north",
                        "south", "east", "west", "up", "down" }))
                    {
                        return "Cannot " + text[0] + " direction!";
                    }
                    else
                    {
                        _itemid = text[1];
                        _container = p.Location as IHaveInventory;
                    }
                    break;
                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want take from?";
                    _container = p as IHaveInventory;
                    _itemid = text[2];
                    break;

                case 4:
                    _container = FetchContainer(p, text[3]); // TODO:THIS IS BROKEN
                    if (_container == null)
                        return "Could not find " + text[3] + ".";
                    _itemid = text[2];
                    break;

                default:
                    _container = null;
                    return error;

            }


            return TakeItemFrom(p,_itemid, _container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private String TakeItemFrom(Player p, string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
                return "Could not find " + thingId;

            GameObject _itemFound = container.Locate(thingId);
            if (_itemFound.GetType() == typeof(Item))
            {
                Item itemGrabbed = container.Take(thingId) as Item;
                if (itemGrabbed == null)
                    return "You can't take " + _itemFound.ShortDescription + " with you.\r\n";
                p.Inventory.Put(itemGrabbed);
            }
            else
                return "error";

            return "You have taken the " + thingId + ".\r\n";
        }
    }
}
