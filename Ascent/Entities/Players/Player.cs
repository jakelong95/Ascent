using Ascent.Resources;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    public abstract class Player : Entity
    {
        public abstract string Description { get; }
        public abstract PlayerClass Class { get; }


        public Player()
            : base(Textures.Character)
        {
            
        }
    }
}
