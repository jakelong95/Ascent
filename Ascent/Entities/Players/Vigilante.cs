using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Vigilante : Player
    {
        public override string Description
        {
            get
            {
                return "A crowd control class. Deals status effects and minimal damage to several targets at once.";
            }
        }
        public override PlayerClass Class { get { return PlayerClass.Vigilante; } }

        public Vigilante()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
