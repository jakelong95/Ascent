using Ascent.Resources;

namespace Ascent.Entities.Players
{
    class Engineer : Player
    {
        public override PlayerClass Class { get { return PlayerClass.Engineer; } }

        public Engineer()
            : base(Textures.PlayerCircle)
        {
                
        }
    }
}
