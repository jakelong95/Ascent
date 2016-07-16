using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Pirate : Player
    {
        public override PlayerClass Class { get { return PlayerClass.Pirate; } }

        public Pirate()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
