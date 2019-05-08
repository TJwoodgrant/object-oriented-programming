using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Nightmaher.Core
{
    public class Path : GameObject
    {

        bool _isBlocked;

        Location _source, _destination;

        public Path(string[] idents, string name, string desc, Location source, Location destination) :
            base(idents, name, desc)
        {
            AddIdentifier("path");
            foreach (string s in name.Split(" "))
            {
                AddIdentifier(s);
            }
            _isBlocked = false;

            _source = source;
            _destination = destination;


        }

        public Location Destination { get => _destination; }


        public override string ShortDescription
        {
            get => Name;
        }

        public bool IsBlocked { get => _isBlocked; set => value = _isBlocked; }

    }

    [TestFixture]
    public class TestPath
    {
        Player _testPlayer;
        Location _testRoomA;
        Location _testRoomB;
        Path _testPath;

        [Test]
        public void TestPathLocation()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            Location _expected = _testRoomB;
            Location _actual = _testPath.Destination;

            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void TestPathName()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            string _expected = "A test door";
            string _actual = _testPath.LongDescription;

            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void TestLocatePath()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            GameObject _expected = _testRoomA.Locate("north");
            GameObject _actual = _testPath;

            Assert.AreEqual(_expected, _actual);
        }

    }
}
