﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt2._2
{
    class Location : GameObject, IHaveInventory
    {

        Inventory _inventory;
        List<Path> _paths;
        //new Dictionary<CardinalDirection, Path> _paths;
        //TODO: Enum for each diretion + dictionary to key->path


        public Location(string name, string desc) :
            base(new string[] {"location", "place", "room" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();

        }

        public Location(string name, string desc, List<Path> paths):
            this(name, desc)
        {
            _paths = paths;

        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
                return this;

            return _inventory.Fetch(id);
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public string PathList
        {
            get
            {
                string list = string.Empty;
                foreach (Path p in _paths)
                {
                    list = list + p.ShortDescription;
                }

                return list;
            }
        }

        public override string ShortDescription { get => "You are in a " + Name; }

        public override string LongDescription { get => base.LongDescription + PathList}


        public Inventory Inventory { get => _inventory; }

        

    }

    [TestFixture]
    class TestLocation
    {
        Location l;
        Player p;

        [Test]
        public void TestLocationIdentifyItself()
        {
            p = new Player("Tohru", "O No Not More References Y U Do Dis");
            l = new Location("Classroom", "A classroom with a few rows of long tables. Each table seems to contain five pieces of junk known as iMacs. ");
            p.Location = l;

            bool actual = l.AreYou("location");

            Assert.IsTrue(actual, "Test Location can identify itself as 'location'");
        }
        


    }
}
