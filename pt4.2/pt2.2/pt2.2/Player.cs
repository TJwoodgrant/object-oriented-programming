using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class Player : GameObject
    {

        //inventory

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            //inventory
        }

        public override string LongDescription
        {
            get => "A simple player. Just Monika.";
        }

        public GameObject Locate(string id)
        {
            return null;
        }

    }
}
