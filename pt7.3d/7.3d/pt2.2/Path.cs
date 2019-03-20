using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class Path : GameObject
    {

        bool _isBlocked;

        public Path(string[] idents, string name, string desc, Location source, Location destination):
            base(idents, name, desc)
        {
            AddIdentifier("Path");
            _isBlocked = false;

            source.AddPath(this);
            destination.AddPath(this);

        }

        public override string ShortDescription
        {
            get => "You travel down a " + Name;
        }

        public bool IsBlocked { get => _isBlocked; set => value = _isBlocked; }

    }
}
