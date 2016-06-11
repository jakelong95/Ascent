using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    public abstract class BaseClass
    {
        protected string name;
        protected string description;
        protected Color classColor;



        //Tried to use getters and setters, 
        //But struggled with protection levels
        //And inheritance. So this is what we get.
        public String getName()
        {
            return name;
        }

        public String getDescription()
        {
            return description;
        }

        public Color getColor()
        {
            return classColor;
        }
    }
}
