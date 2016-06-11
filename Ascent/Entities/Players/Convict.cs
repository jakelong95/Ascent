using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Convict : BaseClass
    {
        public Convict()
        {
            name = "Convict";
            description = "A tank class that can take massive amounts of damage and still stand."
            classColor = Color.Orange;
        }
    }
}
