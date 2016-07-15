using Ascent.EnumUtilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Ascent.Entities.Players
{
    public enum PlayerClass
    {
        [NameValue("Cleric")]
        [DescriptionValue("A support class with several ways to heal and buff allies, as well as rebuke demons.")]
        Cleric,
        [NameValue("Convict")]
        [DescriptionValue("A tank class that can take massive amounts of damage and still stand.")]
        Convict,
        [NameValue("Engineer")]
        [DescriptionValue("A single-target control class. Lays traps that effect one creature and apply mild damage.")]
        Engineer,
        [NameValue("Outlaw")]
        [DescriptionValue("A damage-dealing class with short cool downs and heavy attacks.")]
        Outlaw,
        [NameValue("Pirate")]
        [DescriptionValue("A multi-target damage-dealing class. Deals small amounts of damage to several foes.")]
        Pirate,
        [NameValue("Vigilante")]
        [DescriptionValue("A crowd control class. Deals status effects and minimal damage to several targets at once.")]
        Vigilante
    }
}
