using System;

namespace Ascent.EnumUtilities
{
    public class NameValue : Attribute
    {
        private string value;

        public NameValue(string value)
        {
            this.value = value;
        }

        public string Value { get { return value; } }
    }
}
