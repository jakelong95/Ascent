using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Vigilante : Player
    {
        public override PlayerClass Class { get { return PlayerClass.Vigilante; } }

        public Vigilante()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
