using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt2._2
{
    class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {

            if (_items.Count == 0)
                return false;

            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                    return true;
            }
            return false;
      
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                {
                    Item itemFound = i;
                    _items.Remove(i);
                    return itemFound;
                }
            }
            return null;
        }

        public Item Fetch(String id)
        {

            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                    return i;
            }
            return null;
        }

        public string ItemList
        {
            get
            {

                string list = string.Empty;
                foreach(Item i in _items)
                {
                    list = list + "    " + i.ShortDescription + System.Environment.NewLine;
                }
                return list;
            }

        }

        
    }

    [TestFixture]
    class TestInventory
    {
        Item itm = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion");
        Item itm2 = new Item(new string[] { "potion" }, "blue", "A sour-smelling blue potion");

        [Test]
        public void TestFindItem()
        {
            Inventory i = new Inventory();
            
            i.Put(itm);
            bool actual = i.HasItem(itm.FirstID);

            Assert.IsTrue(actual, "Test Inventory has Item by FirstID");
        }

        [Test]
        public void TestNotFindItem()
        {
            Inventory i = new Inventory();

            i.Put(itm);
            bool actual = i.HasItem("pen");

            Assert.IsFalse(actual, "Test Inventory does not have item by FirstID");
        }

        [Test]
        public void TestFetchItem()
        {
            Inventory i = new Inventory();

            i.Put(itm);
            Item takenItem = i.Fetch(itm.FirstID);

            Assert.AreEqual(takenItem, itm, "Test Inventory Fetch such that item is not taken");
        }

        [Test]
        public void TestTakeItem()
        {
            Inventory i = new Inventory();

            i.Put(itm2);

            Item takenItem = i.Take(itm2.FirstID);

            bool actual = i.HasItem(itm2.FirstID);
            Assert.IsFalse(actual, "Test Inventory Take such that Item cannot be found by AreYou");

        }

        [Test]
        public void TestInventoryItemList()
        {
            Inventory i = new Inventory();

            i.Put(itm);
            i.Put(itm2);
            string actual = i.ItemList;
            string expected = "    a red potion\r\n    a blue potion\r\n";
            Assert.AreEqual(expected, actual, "Test Inventory List String, should be a formatted list");
        }


    }

}
