using System;
using System.Collections.Generic;
using System.Text;

namespace pt2._2
{
    interface IHaveInventory
    {
        GameObject Locate(string id);
        GameObject Take(string id);

        string Name { get; }

    }
}
