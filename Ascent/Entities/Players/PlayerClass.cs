using Ascent.EnumUtilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Ascent.Entities.Players
{
    public enum PlayerClass
    {
        [StringValue("Cleric")]
        Cleric,     //White
        [StringValue("Vigilante")]
        Convict,    //Orange
        [StringValue("Engineer")]
        Engineer,   //LawnGreen
        [StringValue("Outlaw")]
        Outlaw,     //Red
        [StringValue("Pirate")]
        Pirate,     //Purple
        [StringValue("Vigilante")]
        Vigilante   //BlueViolet
    }
}
