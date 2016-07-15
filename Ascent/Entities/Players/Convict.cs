using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Convict : Player
    {
        public override PlayerClass Class { get { return PlayerClass.Convict; } }

        public Convict()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
