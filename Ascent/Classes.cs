using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Ascent
{
    //Because it's not a problem if you stick two reserved words together.
    public enum charClasses {CLERIC, OUTLAW, ENGINEER, PIRATE, CONVICT, VIGILANTE};

    public class Classes
    {
        public static Dictionary<charClasses, Color> colorMap = new Dictionary<charClasses, Color>();

        //Populate the color mapping
        public static void initialize()
        {
            colorMap.Add(charClasses.CLERIC, Color.White);
            colorMap.Add(charClasses.OUTLAW, Color.Red);
            colorMap.Add(charClasses.ENGINEER, Color.LawnGreen);
            colorMap.Add(charClasses.PIRATE, Color.Purple);
            colorMap.Add(charClasses.CONVICT, Color.Orange);
            colorMap.Add(charClasses.VIGILANTE, Color.Blue);
        }

    }
}
