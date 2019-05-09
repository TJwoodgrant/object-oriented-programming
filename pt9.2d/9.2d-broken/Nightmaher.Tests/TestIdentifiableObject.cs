using System;
using System.Collections.Generic;
using System.Text;
using Nightmaher.Core;
using NUnit.Framework;

namespace Nightmaher.Tests
{
    [TestFixture]
    class TestIdentifiableObject
    {
        IdentifiableObject io = new IdentifiableObject(new string[] { "person", "bob" });


        [Test]
        public void TestAreYou()
        {
            bool actual = io.AreYou("Person");

            Assert.IsTrue(actual, "IO AreYou identifier found");
        }

        [Test]
        public void TestNotAreYou()
        {
            bool actual = io.AreYou("Sally");

            Assert.IsFalse(actual, "IO Not Are You");
        }

        [Test]
        public void TestCaseSensitive()
        {
            bool actual = io.AreYou("PERSON");

            Assert.IsTrue(actual, "IO Case Sensitive AreYou");
        }

        [Test]
        public void TestFirstID()
        {
            string actual = io.FirstID;

            Assert.AreEqual("person", actual, "IO Test First ID to be person");

        }

        [Test]
        public void TestAddID()
        {
            io.AddIdentifier("bob");

            bool actual = io.AreYou("bob");

            Assert.IsTrue(actual, "IO Test Bob has been added");
        }
    }
}
