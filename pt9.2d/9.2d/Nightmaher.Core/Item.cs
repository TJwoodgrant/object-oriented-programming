using System;
using System.Collections.Generic;
using System.Text;

namespace Nightmaher.Core
{   
    public class Item : GameObject
    {
        private bool _canBeTaken;

        public Item(string[] idents, string name, string desc) :
            base(idents, name, desc)
        {
            _canBeTaken = true;
        }

        public Item(string[] idents, string name, string desc, bool CanBeTaken) :
            this(idents, name, desc)
        {
            _canBeTaken = CanBeTaken;
        }

        public bool CanBeTaken
        {
            get => _canBeTaken;
        }
    }

}
