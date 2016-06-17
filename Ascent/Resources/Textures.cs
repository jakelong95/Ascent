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
        public static Texture2D Character;
        public static Texture2D PlayerCircle;

        public static Texture2D LeftArrow;
        public static Texture2D RightArrow;


        public static void load(ContentManager content)
        {
            Character = content.Load<Texture2D>("textures/character");
            PlayerCircle = content.Load<Texture2D>("textures/dotWhite");
            LeftArrow = content.Load<Texture2D>("textures/LeftArrow");
            RightArrow = content.Load<Texture2D>("textures/RightArrow");
        }
    }
}
