using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Ascent.Entities.Players;


namespace Ascent
{
    //Because it's not a problem if you stick two reserved words together.
    public enum charClasses {CLERIC, OUTLAW, ENGINEER, PIRATE, CONVICT, VIGILANTE};

    public class Classes
    {
        public static Dictionary<charClasses, BaseClass> colorMap = new Dictionary<charClasses, BaseClass>();

        //Populate the color mapping
        public static void initialize()
        {
            colorMap.Add(charClasses.CLERIC, new Cleric());
            colorMap.Add(charClasses.OUTLAW, new Outlaw());
            colorMap.Add(charClasses.ENGINEER, new Engineer());
            colorMap.Add(charClasses.PIRATE, new Pirate());
            colorMap.Add(charClasses.CONVICT, new Convict());
            colorMap.Add(charClasses.VIGILANTE, new Vigilante());
        }

    }
}
