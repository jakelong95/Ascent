using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent
{
    class MovementManager
    {
        public static List<GravPoint> GravityItems = new List<GravPoint>();

        public MovementManager()
        {

        }

        //Takes in an entity and a location. Uses weighted grav/anti grav to
        //Determine a path.
        public static void Move(Entities.Entity entity, Vector2 destination)
        {

        }

    }

    class GravPoint
    {
        //Note that power must be negative to repel
        public double x;

        public double y;

        public double power;

        public GravPoint(double pX, double pY, double pPower)
        {
            this.x = pX;
            this.y = pY;
            this.power = pPower;
        }
    }
}
