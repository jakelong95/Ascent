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
            [PlayerClass.Cleric] = Color.White,
            [PlayerClass.Convict] = Color.Orange,
            [PlayerClass.Engineer] = Color.LawnGreen,
            [PlayerClass.Outlaw] = Color.Red,
            [PlayerClass.Pirate] = Color.Purple,
            [PlayerClass.Vigilante] = Color.BlueViolet
        };

        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValue[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValue), false) as StringValue[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].Value : null;
        }

        public static Color GetColor(this PlayerClass value)
        {
            return PlayerColors[value];
        }
    }
}
