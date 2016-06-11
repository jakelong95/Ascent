using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ascent.Resources;
using Ascent.Entities.Players;


namespace Ascent.ScreenManager.Screens
{
    public class CharacterSelectionScreen : BaseScreen
    {

        charClasses classSel = charClasses.CLERIC;
        Player tempPlayer = new Player();
        BaseClass tempClass; //Used to store current selected class (out variable).

            public CharacterSelectionScreen()
            {
                name = "CharacterSelectionScreen";
                state = ScreenState.Active;
                Classes.charMap.TryGetValue(classSel, out tempClass);
                tempPlayer.playerClass = tempClass;
            }

            public override void Draw(SpriteBatch spritebatch)
            {
                spritebatch.Begin();
                //TODO: How do I know screen size locations?

                spritebatch.DrawString(Fonts.centaur10, tempPlayer.playerClass.getName(), new Vector2(282 - Fonts.centaur10.MeasureString(tempPlayer.playerClass.getName()).X / 2, 200), Color.White);
                spritebatch.DrawString(Fonts.centaur10, tempPlayer.playerClass.getDescription(), new Vector2(282 - Fonts.centaur10.MeasureString(tempPlayer.playerClass.getDescription()).X / 2, 320), Color.White);

                spritebatch.Draw(Textures.leftArrow, new Rectangle(180, 250, 64, 64), Color.White);
                spritebatch.Draw(Textures.rightArrow, new Rectangle(320, 250, 64, 64), Color.White);
                spritebatch.Draw(Textures.playerCircle, new Rectangle(250, 250, 64, 64), tempPlayer.playerClass.getColor());
                spritebatch.End();

            }

            public override void Update(float delta)
            {
                
            }

            public override void HandleInput()
            {
                //TODO or if I click on the left arrow?
                if (Input.KeyPressed(Keys.Left))
                {
                    classSel = (charClasses)Utilities.nextSmallestEnum(typeof(charClasses), (int)classSel);
                }
                else if (Input.KeyPressed(Keys.Right))
                {
                    classSel = (charClasses)Utilities.nextGreatestEnum(typeof(charClasses), (int)classSel);
                }
                

                Classes.charMap.TryGetValue(classSel, out tempClass);
                tempPlayer.playerClass = tempClass;
            }

    }
}
