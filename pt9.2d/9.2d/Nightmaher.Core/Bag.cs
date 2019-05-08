using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Nightmaher.Core
{
    public class Bag : Item, IHaveInventory
    {
        Inventory _inventory;

        public Bag(string[] ids, string name, string desc) :
            base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public Bag(string[] ids, string name, string desc, bool CanBeTaken) :
            base(ids, name, desc, CanBeTaken)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
                return this;

            return _inventory.Fetch(id);
        }

        public GameObject Take(string id)
        {
            return _inventory.Take(id);
        }

        public override string LongDescription
        {
            get
            {
                if (_inventory.Count != 0)
                    return base.LongDescription + "\r\nThe " + FirstID + " has: \r\n" + _inventory.ItemList;
                else
                    return base.LongDescription;
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

    }

}
