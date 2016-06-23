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
    public enum PlayerClasses { CLERIC, OUTLAW, ENGINEER, PIRATE, CONVICT, VIGILANTE };		
		
    public class Classes
    {		
        public static Dictionary<PlayerClasses, Player> charMap = new Dictionary<PlayerClasses, Player>();		
		
        //Populate the color mapping		
        public static void initialize()
        {		
            charMap.Add(PlayerClasses.CLERIC, new Cleric());		
            charMap.Add(PlayerClasses.OUTLAW, new Outlaw());		
            charMap.Add(PlayerClasses.ENGINEER, new Engineer());		
            charMap.Add(PlayerClasses.PIRATE, new Pirate());		
            charMap.Add(PlayerClasses.CONVICT, new Convict());		
            charMap.Add(PlayerClasses.VIGILANTE, new Vigilante());		
        }		
		
    }		
}