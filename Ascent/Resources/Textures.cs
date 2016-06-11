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
        public static Texture2D playerCircle;
        public static Texture2D leftArrow;
        public static Texture2D rightArrow;


        public static void load(ContentManager content)
        {
            character = content.Load<Texture2D>("textures/character");
            playerCircle = content.Load<Texture2D>("textures/dotWhite");
            leftArrow = content.Load<Texture2D>("textures/LeftArrow");
            rightArrow = content.Load<Texture2D>("textures/RightArrow");
        }
    }
}
