using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Outlaw : Player
    {
        public override string Description
        {
            get
            {
                return "A damage-dealing class with short cooldowns and heavy attacks.";
            }
        }
    }
}
