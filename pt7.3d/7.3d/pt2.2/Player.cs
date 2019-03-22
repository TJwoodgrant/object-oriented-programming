using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt2._2
{
    class Player : GameObject, IHaveInventory
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
                string desc = new string("");
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


    [TestFixture]
    class TestPlayer
    {
        
        Item redPot = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion");

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Player p = new Player("MC", "The player");

            bool actual = p.AreYou("me");
            Assert.IsTrue(actual);

            actual = p.AreYou("inventory");
            Assert.IsTrue(actual);

        }

        [Test]
        public void TestPlayerCanLocateThemselves()
        {
            Player p = new Player("MC", "The player");

            GameObject expected = p;
            GameObject actual = p.Locate("me");
            Assert.AreEqual(expected, actual, "Test Player.Locate to see if player can locate themselves");
        }

        [Test]
        public void TestPlayerCanLocateItems()
        {
            Player p = new Player("MC", "The player");

            p.Inventory.Put(redPot);

            GameObject expected = redPot;
            GameObject actual = p.Locate(redPot.FirstID);

            Assert.AreEqual(expected, actual, "Test Player can locate items within their inventory");

        }

        [Test]
        public void TestPlayerCanLocateNothing()
        {
            Player p = new Player("MC", "The player");

            GameObject expected = null;
            GameObject actual = p.Locate(redPot.FirstID);

            Assert.AreEqual(expected, actual, "Test Player can correctly return NULL if no item is found");
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Player p = new Player("MC", "The player");

            string expected = "The player";
            string actual = p.LongDescription;

            Assert.AreEqual(expected, actual, "Test Player has correct long description");
        }


    }
}
