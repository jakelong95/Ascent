using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Cleric : Player
    {
        public override string Description
        {
            get { return "A support class with several ways to heal and buff allies, as well as rebuke demons."; }
        }
        public override PlayerClass Class { get { return PlayerClass.Cleric; } }

        public Cleric()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
