using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Convict : Player
    {
        public override string Description
        {
            get
            {
                return "A tank class that can take massive amounts of damage and still stand.";
            }
        }
        public override PlayerClass Class { get { return PlayerClass.Convict; } }
    }
}
