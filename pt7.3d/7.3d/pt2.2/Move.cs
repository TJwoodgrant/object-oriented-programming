using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt2._2
{
    class Move : Command
    {
        public Move() :
            base(new string[] { "move", "stare", "glimpse" })
        {
            
        }

        public override string Execute(Player p, string[] text)
        {
            string error = "Error in move input.";
            string _moveDir;

            switch (text.Length)
            {
                case 1:
                    return "Move where?";

                case 2:
                    _moveDir = text[1].ToLower();
                    break;

                case 3:
                    _moveDir = text[2].ToLower();
                    break;

                default:
                    return error;
            }

            GameObject _path = p.Location.Locate(_moveDir);
            if (_path != null)
            {
                if (_path.GetType() != typeof(Path))
                    return "Could not find the " + _path.Name;
                p.Move((Path)_path);
                return "You have moved " + _path.FirstID + " through a " + _path.Name  + " to the " + p.Location.Name + ".\r\n\n" +
                    p.Location.LongDescription;
            } else
            {
                return error;
            }

        }

        
    }

    [TestFixture]
    public class TestMove
    {
        Move _moveCommand;
        Player _testPlayer;
        Location _testRoomA;
        Location _testRoomB;
        Path _testPath;
      

        [Test]
        public void TestMoveOnPlayer()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");
            
            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            _moveCommand.Execute(_testPlayer, new string[] { "move", "to", "north" });

            String _expected = _testRoomB.Name;
            String _actual = _testPlayer.Location.Name;
            Assert.AreEqual(_expected, _actual, "Testing that move can move the player");

        }

        [Test]
        public void TestMoveString()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);


            

            String _expected = "You have moved north through a Door to the Room B.\r\n\nRoom B\r\n\n\r\nThere are exits to the ";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move", "to", "north" }); ;
            Assert.AreEqual(_expected, _actual, "Testing that move string is correct");

        }

        [Test]
        public void TestInvalidMoveNoArg()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);


            

            String _expected = "Move where?";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move" }); ;
            Assert.AreEqual(_expected, _actual, "Testing invalid move: no path specified");
        }

        [Test]
        public void TestInvalidMoveBadArg()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);

            String _expected = "Error in move input.";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move", "east" }); ;
            Assert.AreEqual(_expected, _actual, "Testing invalid move: non existent path");
        }
        [Test]
        public void TestInvalidMoveNoLocation()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testPlayer.Location = _testRoomA;

            String _expected = "Error in move input.";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move", "east" }); ;
            Assert.AreEqual(_expected, _actual, "Testing invalid move: non existent path");
        }


    }
}
