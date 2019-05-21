using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightmaher.Core
{
    public class Put : Command
    {

        public Put()
            : base(new string[] { "put", "throw" })
        {

        }


        public override string Execute(Player p, string[] text)
        {
            //Put NOUN on/in NOUN (Put Sweet on Table)
            //put  * --> Error
            //put NOUN * --> Put in room

            IHaveInventory _targetContainer = null;
            string _itemid;
            string error = "Error in put input.";

            switch (text.Length)
            {
                case 1:
                    return "Put what?";

                case 2:
                    _itemid = text[1];
                    _targetContainer = p.Location as IHaveInventory;
                    break;

                case 4:
                    _itemid = text[1];
                    _targetContainer = FetchContainer(p, text[3]);
                    if (_targetContainer == null)
                        return "Could not find " + text[3] + ".\r\n";
                    break;


                default:
                    _targetContainer = null;
                    return error;

            }

            return PutItemIn(p, _itemid, _targetContainer);
        }

        private string PutItemIn(Player p, string thingId, IHaveInventory targetContainer)
        {
            if (p.Locate(thingId) == null)
                return "You don't have a " + thingId + "\r\n";
            Item itemToMove = p.Inventory.Take(thingId) as Item;
            targetContainer.Put(itemToMove);

            return "You have put away the " + thingId + "\r\n";
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }
    }
}
