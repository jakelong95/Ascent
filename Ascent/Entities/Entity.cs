using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Ascent.Entities
{
    public abstract class Entity
    {
		protected float health;

		protected Vector2 position;
		protected Vector2 velocity;

		protected float rotation;
		protected float rotationVelocity;

		protected Texture2D texture;
        protected Vector2 size; //Size of the texture 

		//Subclasses need to instantiate this and use their own indices
		protected Attack[] attacks;

		public void Update(GameTime gameTime)
		{
			float ms = gameTime.ElapsedGameTime.Milliseconds;

			//Update position
			position.X += velocity.X * ms;
			position.Y += velocity.Y * ms;

			//Update rotation
			rotation += rotationVelocity * ms;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, null, null, null, rotation, null, null, SpriteEffects.None, 0f);
		}

		public bool IsAlive()
		{
			return health > 0;
		}

		public void SetPosition(float x, float y)
		{
			position.X = x;
			position.Y = y;
		}

		public Vector2 GetPosition()
		{
			return position;
		}

        public Vector2 GetSize()
        {
            return size;
        }

		public void SetVelocity(float x, float y)
		{

		}
    }
}
