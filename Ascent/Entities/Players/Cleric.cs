using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    class Cleric : Player
    {
        public override string Description
        {
            get { return "A support class with several ways to heal and buff allies, as well as rebuke demons."; }
        }
    }
}
