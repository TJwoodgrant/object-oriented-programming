using System;
using System.Collections.Generic;
using System.Text;
using Nightmaher.Core;
using NUnit.Framework;

namespace Nightmaher.Tests
{

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
