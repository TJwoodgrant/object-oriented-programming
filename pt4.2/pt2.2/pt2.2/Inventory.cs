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
            throw new NotImplementedException();
        }

        public Item Fetch(String id)
        {
            throw new NotImplementedException();
        }

        public string ItemList
        {
            get => null;
        }

        
    }

    [TestFixture]
    class TestInventory
    {
        Inventory i = new Inventory();
        Item itm = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion");

        [Test]
        public void TestFindItem()
        {

            i.Put(itm);
            bool actual = i.HasItem(itm.FirstID);

            Assert.IsTrue(actual, "Test Inventory has Item by FirstID");
        }

        [Test]
        public void TestNotFindItem()
        {

            bool actual = i.HasItem("pen");

            Assert.IsFalse(actual, "Test Inventory does not have item by FirstID");
        }

        [Test]
        public void TestFetchItem()
        {

        }


    }

}
