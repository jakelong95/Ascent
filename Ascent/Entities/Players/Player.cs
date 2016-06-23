using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    public class Player : Entity
    {
        public virtual string Description { get; }
        public virtual PlayerClass Class { get; }

        public Vector2 CenterOffset { get; private set; }

        public Player()
        {
            texture = Ascent.Resources.Textures.Character;

            textureSize = new Vector2(64, 64);
            CenterOffset = textureSize / 2;
        }
    }
}
