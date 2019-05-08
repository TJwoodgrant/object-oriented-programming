using System;
using System.Collections.Generic;
using System.Text;

namespace Nightmaher.Core
{
    public class Player : GameObject, IHaveInventory
    {

        Inventory _inventory;
        Location _location;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string LongDescription
        {
            get
            {
                string desc = new string("".ToCharArray());
                desc = desc + "You are " + Name + ", " + base.LongDescription +
                    "\r\nYou are carrying: \r\n" + _inventory.ItemList;
                return desc;
            }
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
                return this;

            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
                return obj;
            if (_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            } else
            {
                return null;
            }
            
        }

        public Location Location{ get => _location; set => _location = value;  }
        public void Move(Path path)
        {
            if(path.Destination != null)
            {
                _location = path.Destination;
            }
        }

        public GameObject Take(string id)
        {
            return Inventory.Take(id);
        }

        public Inventory Inventory { get => _inventory; }

    }



}
