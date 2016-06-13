using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
	public class Player : Entity
	{
        //Do players need a classcolor?
        //It would always be equal to playerClass.getColor();
       public BaseClass playerClass { get; set; }
       public Vector2 offset { get; set; }

        public Player()
       {
           texture = Ascent.Resources.Textures.character;
           size = new Vector2(64, 64);
           offset = size / 2;
       }
	}
}
