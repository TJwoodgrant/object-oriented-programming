using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightmaher.Core
{
    public class Put : Command
    {

        public Put()
            : base(new string[] { "put" })
        {
            
        }


        public override string Execute(Player p, string[] text)
        {
            //Put NOUN on/in NOUN (Put Sweet on Table)
            //put  * --> Error
            throw new NotImplementedException("sorry.");
        }
    }
}
