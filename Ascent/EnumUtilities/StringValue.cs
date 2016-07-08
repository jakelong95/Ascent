using System;

namespace Ascent.EnumUtilities
{
    public class StringValue : Attribute
    {
        private string value;

        public StringValue(string value)
        {
            this.value = value;
        }

        public string Value { get { return value; } }
    }
}
