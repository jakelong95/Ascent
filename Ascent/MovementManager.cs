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
        public static List<Vector2> GravityItems = new List<Vector2>();

        public MovementManager()
        {

        }

        //Takes in an entity and a location. Uses weighted grav/anti grav to
        //Determine a path.
        public static void Move(Entities.Entity entity, Vector2 destination)
        {

        }
    }
}
