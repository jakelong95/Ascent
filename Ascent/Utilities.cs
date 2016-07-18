using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ascent
{
    class Utilities
    {
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static float CenterTextX(SpriteFont font, string text)
        {
            return Game1.temporaryGraphicsDevice.Viewport.Width / 2 - font.MeasureString(text).X / 2;
        }
    }
}
