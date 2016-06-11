using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Ascent.Resources
{
    class Fonts
    {
        public static SpriteFont centaur10;


        public static void load(ContentManager content)
        {
            centaur10 = content.Load<SpriteFont>("fonts/Centaur_10");

        }
    }
}
