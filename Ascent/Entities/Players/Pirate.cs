using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Pirate : Player
    {
        public override string Description
        {
            get
            {
                return "A multi-target damage-dealing class. Deals small amounts of damage to several foes.";
            }
        }
        public override PlayerClass Class { get { return PlayerClass.Pirate; } }

        public Pirate()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
