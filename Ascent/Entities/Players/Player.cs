using Microsoft.Xna.Framework.Graphics;

namespace Ascent.Entities.Players
{
    public abstract class Player : Entity
    {
        public abstract string Description { get; }
        public abstract PlayerClass Class { get; }

        public Player(Texture2D texture)
            : base(texture)
        {

        }

        //TODO Input processing
    }
}
