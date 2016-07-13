using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Engineer : Player
    {
        public override string Description
        {
            get
            {
                return "A single-target control class. Lays traps that effect one creature and apply mild damage.";
            }
        }
        public override PlayerClass Class { get { return PlayerClass.Engineer; } }

        public Engineer()
            : base(Textures.PlayerCircle)
        {

        }
    }
}
