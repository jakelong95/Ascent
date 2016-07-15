using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Outlaw : Player
    {
        public override PlayerClass Class { get { return PlayerClass.Outlaw; } }

        public Outlaw()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
