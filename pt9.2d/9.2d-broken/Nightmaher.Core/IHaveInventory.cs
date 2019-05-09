using System;
using System.Collections.Generic;
using System.Text;

namespace Nightmaher.Core
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);
        GameObject Take(string id);

        string Name { get; }

    }
}
