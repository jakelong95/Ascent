using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Convict : Player
    {
        public override string Description
        {
            get
            {
                return "A tank class that can take massive amounts of damage and still stand.";
            }
        }
        public override PlayerClass Class { get { return PlayerClass.Convict; } }

        public Convict()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
