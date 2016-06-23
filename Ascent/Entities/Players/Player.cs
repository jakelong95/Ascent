using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    public abstract class Player : Entity
    {
        public abstract string Description { get; }

        public Vector2 CenterOffset { get; private set; }

        public Player()
        {
            texture = Ascent.Resources.Textures.character;

            textureSize = new Vector2(64, 64);
            CenterOffset = textureSize / 2;
        }
    }
}
