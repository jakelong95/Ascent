using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ascent.Entities.Players;

namespace Ascent.ScreenManager.Screens
{
    class CharacterSelectionScreen : BaseScreen
    {
        charClasses classSel = charClasses.CLERIC;
        BaseClass tempClass; //Used to store current selected class.

            public CharacterSelectionScreen()
            {
                name = "CharacterSelectionScreen";
                state = ScreenState.Active; 
            }

            public override void Draw(SpriteBatch spritebatch)
            {
                //Todo: draw a circle colored charmap.get(charSel).getColor()
                Classes.charMap.TryGetValue(classSel, out tempClass);
               
                //TODO: draw our left and rigth arrows
            }

            public override void Update(float delta)
            {
                //TODO process our enum, get next smallest, largest
                //And update classSel appropriately


            }

    }
}
