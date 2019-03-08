﻿    using System;
using System.Collections.Generic;
using System.Text;

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
            return _identifiers.Contains(ident);
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
}
