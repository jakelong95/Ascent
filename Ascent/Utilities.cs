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


        //Returns the largest value in an enum that is smaller than val unless
        //val is the smallest value, in which case it returns the largest value in the enum
        //Precondition: the enum must be sorted in ascending order
        public static long nextSmallestEnum(Type enumType, int val)
        {
            bool isFirst = true;
            long prev = -1;
            foreach (int i in Enum.GetValues(enumType))
            {
                if (i < val)
                {
                    prev = i;
                    isFirst = false;
                }
                else
                {
                    if (i == val && isFirst == true)//First element, return biggest
                    {
                        return MaxEnum(enumType);
                    }
                    else
                    {//If sorted, i will never be greater than val
                        return prev;
                    }
                }
            }
            //Shouldn't be reached
            return MaxEnum(enumType);
        }


        //Returns the smallest value in the enum that is greater than val 
        //Unless val is the biggest values, in which case it returns the 
        //Smallest value.
        //Precondition: enum is sorted in ascending order
        public static long nextGreatestEnum(Type enumType, int val)
        {
            foreach (int i in Enum.GetValues(enumType))
            {
                //If I pass the highest valuem, return the lowest
                if (val == MaxEnum(enumType))
                {
                    return minEnum(enumType);
                }
                //Else iterate through each value in enum
                if (i <= val)
                {
                    //Do nothing
                }
                else
                {
                    return i;
                }
            }
            //Shouldn't be reached
            return MaxEnum(enumType);
        }
    }
}
