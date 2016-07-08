using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Outlaw : Player
    {
        public override string Description
        {
            get
            {
                return "A damage-dealing class with short cooldowns and heavy attacks.";
            }
        }
        public override PlayerClass Class { get { return PlayerClass.Outlaw; } }

        public Outlaw()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
