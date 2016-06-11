using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Outlaw : BaseClass
    {
        public Outlaw()
        {
            name = "Outlaw";
            description = "A damage-dealing class with short cooldowns and heavy attacks."
            classColor = Color.Red;
        }
    }
}
