using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Engineer : Player
    {
        public override string Description
        {
            get
            {
                return "A single-target control class. Lays traps that effect one creature and apply mild damage.";
            }
        }
    }
}
