﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt2._2
{
    class Player : GameObject, IHaveInventory
    {

        Inventory _inventory;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string LongDescription
        {
            get => "You are " + Name + ", a mere shadow in the literature club.";
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
                return this;

            return _inventory.Fetch(id);
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

            string expected = "You are MC, a mere shadow in the literature club.";
            string actual = p.LongDescription;

            Assert.AreEqual(expected, actual, "Test Player has correct long description");
        }


    }
}
