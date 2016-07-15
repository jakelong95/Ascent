using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Cleric : Player
    {
        public override PlayerClass Class { get { return PlayerClass.Cleric; } }

        public Cleric()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
