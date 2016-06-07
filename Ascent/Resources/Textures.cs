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
    class Textures
    {
        public static Texture2D character;

        public static void load(ContentManager content)
        {
           // character = content.Load<Texture2D>("textures/character");
        }
    }
}
