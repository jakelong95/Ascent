using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace Ascent.Entities
{
	public abstract class Entity
	{
		public float Health { get; protected set; }

		//Want to make this properties, but can't figure out how to make it work with setting indidiual parts of them
		public Vector2 positon;
		public Vector2 velocity;

		public float Rotation { get; protected set; }
		protected float rotationVelocity;

		protected Texture2D texture;
		protected Vector2 textureSize;
		public Vector2 CenterOffset { get; private set; }


		//Subclasses need to instantiate this and use their own indices
		protected Attack[] attacks;

		public Entity(Texture2D texture)
		{
			this.texture = texture;

			textureSize = new Vector2(texture.Width, texture.Height);
			CenterOffset = textureSize / 2;
		}

		public virtual void Update(GameTime gameTime)
		{
			float ms = gameTime.ElapsedGameTime.Milliseconds;

			//Update Position
			positon.X += velocity.X * ms;
			positon.Y += velocity.Y * ms;

			//Update rotation
			Rotation += rotationVelocity * ms;
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, positon, null, null, null, Rotation, null, null, SpriteEffects.None, 0f);
		}

		public bool IsAlive()
		{
			return Health > 0;
		}

		public void SetPosition(float x, float y)
		{
			positon.X = x;
			positon.Y = y;
		}

		public Vector2 GetPosition()
		{
			return positon;
		}

		public Vector2 GetSize()
		{
			return textureSize;
		}

		public void SetVelocity(float x, float y)
		{

		}


	//     void antiGravMove()
	//    {
	//        double xforce = 0;
	//        double yforce = 0;
	//        double force;
	//        double ang;
	//        GravPoint p;
	//        for (int i = 0; (i < MovementManager.GravityItems.Count); i++)
	//        {
	//            p = ((GravPoint)(MovementManager.GravityItems[i]));
	//            // Calculate the total force from this point on us
	//            force = (p.power / Math.Pow(getRange(GetPosition().X, GetPosition().Y, p.x, p.y), 2));
	//            // Find the bearing from the point to us
	//            ang = normalizeBearing(((Math.PI / 2)
	//                            - Math.Atan2((GetPosition().Y - p.y), (GetPosition().X - p.x))));
	//            // Add the components of this force to the total force in their 
	//            // respective directions
	//            xforce = (xforce
	//                        + (Math.Sin(ang) * force));
	//            yforce = (yforce
	//                        + (Math.Cos(ang) * force));
	//        }

	//        /**The following four lines add wall avoidance.  They will only 
	//            affect us if the bot is close to the walls due to the
	//            force from the walls decreasing at a power 3.**/
	//         //HOW DO I GET THE WIDTH OF MY SCREEN YO
	//        int SCREENWIDTH = 500; int SCREENHEIGHT = 500; //TODO FIX THIS GARBAGE
	//        xforce = (xforce + (5000 / Math.Pow(getRange(GetPosition().X, GetPosition().Y, SCREENWIDTH, GetPosition().Y), 3)));
	//        xforce = (xforce - (5000 / Math.Pow(getRange(GetPosition().X, GetPosition().Y, 0, GetPosition().Y), 3)));
	//        yforce = (yforce + (5000 / Math.Pow(getRange(GetPosition().X, GetPosition().Y, GetPosition().X, SCREENHEIGHT), 3)));
	//        yforce = (yforce - (5000 / Math.Pow(getRange(GetPosition().X, GetPosition().Y, GetPosition().X, 0), 3)));
	//        // Move in the direction of our resolved force.
	//        goTo((GetPosition().X - xforce), (GetPosition().Y - yforce));
	//    }


	//    /**Move in the direction of an x and y coordinate**/
	//void goTo(double x, double y) {
	//    double dist = 20;
	//    double angle = Utilities.RadianToDegree(absbearing(GetPosition().X, GetPosition().Y, x, y));
	//    double r = turnTo(angle);
	//    setAhead((dist * r));
	//}

	///**Turns the shortest angle possible to come to a heading, then returns 
	//the direction the bot needs to move in.**/
	//int turnTo(double angle) {
	//    double ang;
	//    int dir;
	//    ang = normalizeBearing((getHeading() - angle));
	//    if ((ang > 90)) {
	//        ang -= 180;
	//        dir = -1;
	//    }
	//    else if ((ang < -90)) {
	//        ang += 180;
	//        dir = -1;
	//    }
	//    else {
	//        dir = 1;
	//    }
		
	//    setTurnLeft(ang);
	//    return dir;
	//}

	///**Returns the distance between two points**/
	//double getRange(double x1, double y1, double x2, double y2) {
	//    double x = (x2 - x1);
	//    double y = (y2 - y1);
	//    double range = Math.Sqrt(((x * x) 
	//                    + (y * y)));
	//    return range;
	//}

	//        // gets the absolute bearing between to x,y coordinates
	//public double absbearing(double x1, double y1, double x2, double y2) {
	//    double xo = (x2 - x1);
	//    double yo = (y2 - y1);
	//    double h = getRange(x1, y1, x2, y2);
	//    if (((xo > 0) 
	//                && (yo > 0))) {
	//        return Math.Asin((xo / h));
	//    }
		
	//    if (((xo > 0) 
	//                && (yo < 0))) {
	//        return (Math.PI - Math.Asin((xo / h)));
	//    }
		
	//    if (((xo < 0) 
	//                && (yo < 0))) {
	//        return (Math.PI + Math.Asin(((xo / h) 
	//                        * -1)));
	//    }
		
	//    if (((xo < 0) 
	//                && (yo > 0))) {
	//        return ((2 * Math.PI) 
	//                    - Math.Asin(((xo / h) 
	//                        * -1)));
	//    }
		
	//    return 0;
	//}

	////if a bearing is not within the -pi to pi range, alters it to provide the shortest angle
	//double normalizeBearing(double ang)
	//{
	//    if (ang > Math.PI)
	//        ang -= 2 * Math.PI;
	//    if (ang < -Math.PI)
	//        ang += 2 * Math.PI;
	//    return ang;
	//}
	}
}
