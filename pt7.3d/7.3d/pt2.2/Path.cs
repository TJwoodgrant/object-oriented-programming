using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    class Path : IdentifiableObject
    {
        public Path(string[] idents):
            base(idents)
        {
            AddIdentifier("Path");
        }
    }
}
