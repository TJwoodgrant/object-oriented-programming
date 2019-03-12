using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace pt2._2
{
    class IdentifiableObject
    {

        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach(string s in idents)
            {
                _identifiers.Add(s.ToLower());
            }
        }

        public bool AreYou(string ident)
        {
            return _identifiers.Contains(ident.ToLower());
        }

        public string FirstID
        {
            get => _identifiers[0];
        }

        public void AddIdentifier(string ident)
        {
            _identifiers.Add(ident.ToLower());
        }


    }

    [TestFixture]
    class TestIdentifiableObject
    {
        IdentifiableObject io = new IdentifiableObject(new string[] {"person", "bob"});


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
    }
}
