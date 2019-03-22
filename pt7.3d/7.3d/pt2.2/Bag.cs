using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt2._2
{
    class Bag : Item, IHaveInventory
    {
        Inventory _inventory;

        public Bag(string[] ids, string name, string desc) :
            base(ids, name, desc)
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
            get => base.LongDescription + "\r\nInside, you see: \r\n" + _inventory.ItemList;
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

    }

    [TestFixture]
    class TestBag
    {

        Bag b;
        Item redPot = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion.");
        Item whitePot = new Item(new string[] { "potion" }, "white", "A viscous white fluid, like if PLA glue was a potion.");

        [Test]
        public void TestBagLocatesItems()
        {
            b = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag" );
            b.Inventory.Put(redPot);

            GameObject actual = b.Locate(redPot.FirstID);
            GameObject expected = redPot;
            Assert.AreEqual(expected, actual, "Test if a bag can locate an item, test item redpot");
        }

        [Test]
        public void TestBagLocatesItself()
        {
            b = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag");

            GameObject expected = b;
            GameObject actual = b.Locate("bag");

            Assert.AreEqual(expected, actual, "Test if the back can locate itself");
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            b = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag");

            GameObject expected = null;
            GameObject actual = b.Locate("monika.chr");

            Assert.AreEqual(expected, actual, "Test if bag can locate monika.chr. Wait, it's not there? WAIT WHAT HOLLUP--- **static**");
        }

        [Test]
        public void TestBagFullDescription()
        {
            b = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag");

            string expected = "A bag endorned with a six-sided star inside a circle";
            string actual = b.LongDescription;
            Assert.AreEqual(expected, actual, "Test full description of bag");
        }

        [Test]
        public void TestBagInBag()
        {
            Bag b1 = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag");
            Bag b2 = new Bag(new string[] { "medium", "leather", "bag" }, "bag", "A medium-sized bag. For newbies.");

            b1.Inventory.Put(b2);

            b2.Inventory.Put(whitePot);

            GameObject expected = whitePot;
            GameObject actual = b1.Locate(whitePot.FirstID);

            Assert.AreNotEqual(expected, actual, "Test Bag in Bag, that super-bag cannot locate things inside child bag");
        }

    }
}
