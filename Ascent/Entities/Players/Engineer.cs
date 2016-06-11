using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Engineer : BaseClass
    {
        public Engineer()
        {
            name = "Engineer";
            description = "A single-target control class. Lays traps that effect one creature and apply mild damage.";
            classColor = Color.LawnGreen;
        }
    }
}
