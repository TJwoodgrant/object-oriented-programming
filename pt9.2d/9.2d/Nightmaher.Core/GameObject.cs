using System;
using System.Collections.Generic;
using System.Text;

namespace Nightmaher.Core
{
    public abstract class GameObject : IdentifiableObject
    {
        string _description, _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
        public string Name { get => _name; }

        virtual public string ShortDescription { get => "a " + _name + " " + this.FirstID;  }
        virtual public string LongDescription { get =>  _description;  }

    }
}
