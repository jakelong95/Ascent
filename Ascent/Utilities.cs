using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascent
{
    class Utilities
    {
         //Return the greatest value of an enum
        public static long MaxEnum(Type enumType)
        {
            long max = 0;
            bool gotInitialValue = false;
            foreach (int i in Enum.GetValues(enumType))
            {
                if (gotInitialValue == false)
                {
                    gotInitialValue = true;
                    max = i;
                }
                else if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        //Return smallest value of enum
        public static long minEnum(Type enumType)
        {
            long min = long.MinValue;
            bool gotInitialValue = false;
            foreach (int i in Enum.GetValues(enumType))
            {
                if (gotInitialValue == false)
                {
                    gotInitialValue = true;
                    min = i;
                }
                else
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }
            }
            return min;
        }

    }
    }
}
