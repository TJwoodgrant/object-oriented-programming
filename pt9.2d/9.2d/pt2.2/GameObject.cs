using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    abstract class GameObject : IdentifiableObject
    {
        string _description, _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
        public string Name { get => _name; }

        // TODO: Fix to format later

        virtual public string ShortDescription { get => "a " + _name + " " + this.FirstID;  }
        virtual public string LongDescription { get =>  _description;  }

    }
}
