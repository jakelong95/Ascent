using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ascent.Entities.Players
{
    abstract class BaseClass
    {
        public abstract string name { get; protected set; }
        public abstract string description { get; protected set; }
        public abstract Color classColor { get; protected set; }
    }
}
