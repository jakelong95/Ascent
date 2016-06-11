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
        public static Dictionary<charClasses, BaseClass> charMap = new Dictionary<charClasses, BaseClass>();

        //Populate the color mapping
        public static void initialize()
        {
            charMap.Add(charClasses.CLERIC, new Cleric());
            charMap.Add(charClasses.OUTLAW, new Outlaw());
            charMap.Add(charClasses.ENGINEER, new Engineer());
            charMap.Add(charClasses.PIRATE, new Pirate());
            charMap.Add(charClasses.CONVICT, new Convict());
            charMap.Add(charClasses.VIGILANTE, new Vigilante());
        }

    }
}
