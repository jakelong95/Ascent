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
using Ascent.Entities;

namespace Ascent.ScreenManager.Screens
{
    public class CharacterSelectionScreen : BaseScreen
    {

        PlayerClasses classSel = PlayerClasses.CLERIC;
        public static ImageEntity tempPlayer; //The public static part of this is for debug only

        Color leftCol = Color.White;
        Color rightCol = Color.White;

            public CharacterSelectionScreen()
            {
                name = "CharacterSelectionScreen";
                state = ScreenState.Active;
                tempPlayer = new ImageEntity(Textures.PlayerCircle);
                //Classes.charMap.TryGetValue(classSel, out tempClass);
                //tempPlayer.playerClass = tempClass;
                tempPlayer.SetPosition(250, 250);//TODO DEBUG REMOVE
            }

            public override void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Begin();
                //TODO: How do I know screen size locations?
                spriteBatch.DrawString(Fonts.georgia16, "Character Creation Screen", new Vector2(250, 10), Color.White);


                //spriteBatch.DrawString(Fonts.centaur10, tempPlayer.playerClass.getName(), new Vector2(282 - Fonts.centaur10.MeasureString(tempPlayer.playerClass.getName()).X / 2, 200), Color.White);
                //spriteBatch.DrawString(Fonts.centaur10, tempPlayer.playerClass.getDescription(), new Vector2(282 - Fonts.centaur10.MeasureString(tempPlayer.playerClass.getDescription()).X / 2, 320), Color.White);
                      
                spriteBatch.Draw(Textures.LeftArrow, new Rectangle(180, 250, 64, 64), leftCol);
                spriteBatch.Draw(Textures.RightArrow, new Rectangle(320, 250, 64, 64), rightCol);
                //spriteBatch.Draw(Textures.PlayerCircle, new Rectangle((int)tempPlayer.GetPosition().X, (int)tempPlayer.GetPosition().Y, (int)tempPlayer.GetSize().X, (int)tempPlayer.GetSize().Y), tempPlayer.playerClass.getColor());
                spriteBatch.End();
                resetInputs();

            }

            public override void Update(float delta)
            {

            }

            public override void HandleInput()
            {
                //Debug switch to Direct Connect
                if (Input.KeyPressed(Keys.F7))
                {
                    ScreenManager.unloadScreen(name);
                   ScreenManager.addScreen(new GameScreen());
                }

                //TODO or if I click on the left arrow?
                if (Input.KeyPressed(Keys.Left))
                {
                    classSel = (PlayerClasses)Utilities.nextSmallestEnum(typeof(PlayerClasses), (int)classSel);
                    leftCol = Color.Red;
                }
                else if (Input.KeyPressed(Keys.Right))
                {
                    classSel = (PlayerClasses)Utilities.nextGreatestEnum(typeof(PlayerClasses), (int)classSel);
                    rightCol = Color.Red;
                }
                

                //Classes.charMap.TryGetValue(classSel, out tempClass);
                //tempPlayer.playerClass = tempClass;
            }

        private void resetInputs()
        {
            leftCol = Color.White;
            rightCol = Color.White;
        }

    }
}
