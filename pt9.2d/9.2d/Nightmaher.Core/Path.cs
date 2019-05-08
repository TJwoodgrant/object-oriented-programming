using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (string s in name.Split(" ".ToCharArray()));
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

}
