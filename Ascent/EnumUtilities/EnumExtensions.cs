using Ascent.Entities.Players;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ascent.EnumUtilities
{
    public static class EnumExtensions
    {
        //Color is not a valid attribute type, so this is a map from class names to their colors
        private static Dictionary<PlayerClass, Color> PlayerColors = new Dictionary<PlayerClass, Color>()
        {
            { PlayerClass.Cleric, Color.White },
            { PlayerClass.Convict, Color.Orange },
            { PlayerClass.Engineer, Color.LawnGreen },
            { PlayerClass.Outlaw, Color.Red },
            { PlayerClass.Pirate, Color.Purple },
            { PlayerClass.Vigilante, Color.BlueViolet }
        };

        /// <summary>
        /// Gets the name value associated with this enum value.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns>Name value of the enum, if one exists. null otherwise.</returns>
        public static string GetName(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            NameValue[] attribs = fieldInfo.GetCustomAttributes(typeof(NameValue), false) as NameValue[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].Value : null;
        }

        /// <summary>
        /// Gets the description value associated with this enum value.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns>Description value of the enum, if one exists. null otherwise.</returns>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            DescriptionValue[] attribs = fieldInfo.GetCustomAttributes(typeof(DescriptionValue), false) as DescriptionValue[];

            //Return the first if there was a match
            return attribs.Length > 0 ? attribs[0].Value : null;
        }

        /// <summary>
        /// Gets the color for this player class.
        /// </summary>
        /// <param name="value">PlayerClass.</param>
        /// <returns>MonoGame Color for the class.</returns>
        public static Color GetColor(this PlayerClass value)
        {
            return PlayerColors[value];
        }

        /// <summary>
        /// Gets the maximum value for this enum type.
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Maximum value of the enum.</returns>
        public static int MaxValue(this Enum value)
        {
            int maxVal = int.MinValue;

            foreach(int val in Enum.GetValues(value.GetType()))
            {
                maxVal = Math.Max(maxVal, val);
            }

            return maxVal;
        }

        /// <summary>
        /// Gets the minimum value for this enum type.
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Minimum value of the enum.</returns>
        public static int MinValue(this Enum value)
        {
            int minVal = int.MaxValue;

            foreach(int val in Enum.GetValues(value.GetType()))
            {
                minVal = Math.Min(minVal, val);
            }

            return minVal;
        }

        /// <summary>
        /// Gets the next highest value in the enumeration. If the specified value is the highest value,
        /// returns the smallest value in the enumeration.
        /// </summary>
        /// <param name="value">Value in enumeration.</param>
        /// <typeparam name="T">Must be an enumeration.</typeparam>
        /// <returns>Next largest value, or if this value is the largest returns the smallest value.</returns>
        public static T NextValue<T>(this T value) where T : struct, IConvertible
        {
            if(!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            int[] enumValues = (int[]) Enum.GetValues(value.GetType());
            int valueIndex = Array.IndexOf(enumValues, value);

            return (T)(object) ((valueIndex >= enumValues.Length) ? enumValues[0] : enumValues[valueIndex + 1]);
        }

        /// <summary>
        /// Gets the previous value in the enumeration. If the specified value is the lowest value,
        /// returns the smallest value in the enumeration.
        /// </summary>
        /// <typeparam name="T">Must be an enumeration.</typeparam>
        /// <param name="value">Value in enumeration.</param>
        /// <returns>Next smallest value, or if this value is the smallest returns the largest value.</returns>
        public static T PrevValue<T>(this T value) where T : struct, IConvertible
        {
            if(!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            int[] enumValues = (int[]) Enum.GetValues(value.GetType());
            int valueIndex = Array.IndexOf(enumValues, value);

            return (T)(object) ((valueIndex < 0) ? enumValues[enumValues.Length - 1] : enumValues[valueIndex - 1]);
        }
    }
}
