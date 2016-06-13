using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascent
{
    public class Attack
    {
        //This could benefit from a better naming standard. 
        public const float COOLDOWN_STANDARD = 1.0f;
        public const float COOLDOWN_FASTEST = 0.2f * COOLDOWN_STANDARD;
        public const float COOLDOWN_FASTER = 0.3f * COOLDOWN_STANDARD;
        public const float COOLDOWN_FAST = 0.5f * COOLDOWN_STANDARD;
        public const float COOLDOWN_MEDIUM = 3.0f * COOLDOWN_STANDARD;
        public const float COOLDOWN_SLOW = 5.0f * COOLDOWN_STANDARD;
        public const float COOLDOWN_SLOWEST = 10.0f * COOLDOWN_STANDARD;
        public const float COOLDOWN_SUPER_SLOW = 100.0f * COOLDOWN_STANDARD;


        public const float DAMAGE_STANDARD = 1.0f;
        public const float DAMAGE_BASICALLY_NOTHING = .03f * DAMAGE_STANDARD;
        public const float DAMAGE_LOW = .5f * DAMAGE_STANDARD;
        public const float HIGH = 2.0f * DAMAGE_STANDARD;
        public const float VERY_HIGH = 3.0f * DAMAGE_STANDARD;
        public const float MASSIVE = 5.0f * DAMAGE_STANDARD;
    }
}
