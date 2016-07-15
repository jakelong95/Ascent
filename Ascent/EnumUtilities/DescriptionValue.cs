using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascent.EnumUtilities
{
    public class DescriptionValue : Attribute
    {
        private string value;

        public DescriptionValue(string value)
        {
            this.value = value;
        }

        public string Value { get { return value; } }
    }
}
