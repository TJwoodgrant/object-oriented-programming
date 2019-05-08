using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Nightmaher.Core
{
    public class Location : GameObject, IHaveInventory
    {

        Inventory _inventory;
        List<Path> _paths;
        //TODO: Enum for each diretion + dictionary to key->path


        public Location(string name, string desc) :
            base(new string[] {"location", "place", "room", "around" }, name, desc)
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

            foreach(Path p in _paths)
            {
                if (p.AreYou(id))
                    return p;
            }

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
                string list = string.Empty + "\r\n";


                if (_paths.Count == 1)
                {
                    return "\r\n\nThere is an exit " + _paths[0].FirstID + ".\r\n";
                }

                list = list + "There are exits to the ";

                for (int i = 0; i < _paths.Count; i++)
                {

                    if (i == _paths.Count - 1)
                    {
                        list = list + "and " + _paths[i].FirstID + ".\r\n";
                    } else
                    {
                        list = list + _paths[i].FirstID + ", ";
                    }
                }

               

                return list;
            }
        }

        public string ItemList
        {
            get
            {
                 if (_inventory.Count == 0)
                {
                    return "";
                }

                return "In the room you see: \r\n" + _inventory.ItemList;
            }
        }

        public bool HasPath(string direction)
        {
            foreach(Path p in _paths)
            {
                if (p.FirstID.ToLower() == direction.ToLower())
                    return true;
            }
            return false;
        }

        public GameObject Take(string id)
        {
            return _inventory.Take(id);
        }

        public override string ShortDescription { get => "You are in a " + Name; }

        public override string LongDescription { get => base.LongDescription + "\r\n\n" + ItemList + PathList; }


        public Inventory Inventory { get => _inventory; }
        public List<Path> Paths { get => _paths; }

        

        

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
