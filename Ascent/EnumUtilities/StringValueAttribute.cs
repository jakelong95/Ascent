using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascent.EnumUtilities
{
    public class StringValueAttribute
    {
        private string value;

        public StringValueAttribute(string value)
        {
            this.value = value;
        }

        public string Value { get { return value; } }
    }
}
