using Ascent.Resources;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    public abstract class Player : Entity
    {
        public virtual string Description { get; }
        public virtual PlayerClass Class { get; }


        public Player()
            : base(Textures.Character)
        {
            
        }
    }
}
