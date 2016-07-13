using Ascent.EnumUtilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Ascent.Entities.Players
{
    public enum PlayerClass
    {
        [StringValue("Cleric")]
        Cleric,
        [StringValue("Vigilante")]
        Convict,
        [StringValue("Engineer")]
        Engineer,
        [StringValue("Outlaw")]
        Outlaw,
        [StringValue("Pirate")]
        Pirate,
        [StringValue("Vigilante")]
        Vigilante
    }
}
