using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Pirate : BaseClass
    {
        public Pirate()
        {
            name = "Pirate";
            description = "A multi-target damage-dealing class. Deals small amounts of damage to several foes.";
            classColor = Color.Purple;
        }
    }
}
