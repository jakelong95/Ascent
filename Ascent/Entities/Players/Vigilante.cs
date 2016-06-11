using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Vigilante : BaseClass
    {
        public Vigilante()
        {
            name = "Vigilante";
            description = "A crowd control class. Deals status effects and minimal damage to several targets at once.";
            classColor = Color.CadetBlue;
        }
    }
}
