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
using Ascent.EnumUtilities;

namespace Ascent.ScreenManager.Screens
{
    public class CharacterSelectionScreen : BaseScreen
    {

        private PlayerClass selectedClass;
        public static ImageEntity tempPlayer; //The public static part of this is for debug only

        Color leftCol = Color.White;
        Color rightCol = Color.White;

        public CharacterSelectionScreen(Game game) : base(game)
        {
            name = "CharacterSelectionScreen";
            state = ScreenState.Active;
            tempPlayer = new ImageEntity(Textures.PlayerCircle);
            tempPlayer.SetPosition(250, 250);//TODO DEBUG REMOVE

            selectedClass = PlayerClass.Cleric;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //TODO: How do I know screen size locations?
            //game.GraphicsDevice.Viewport.Width/Height
            spriteBatch.DrawString(Fonts.georgia16, "Character Creation Screen", new Vector2(250, 10), Color.White);


            spriteBatch.DrawString(Fonts.centaur10, selectedClass.GetName(), new Vector2(282 - Fonts.centaur10.MeasureString(selectedClass.GetName()).X / 2, 200), Color.White);
            spriteBatch.DrawString(Fonts.centaur10, selectedClass.GetDescription(), new Vector2(282 - Fonts.centaur10.MeasureString(selectedClass.GetDescription()).X / 2, 320), Color.White);
                  
            spriteBatch.Draw(Textures.LeftArrow, new Rectangle(180, 250, 64, 64), leftCol);
            spriteBatch.Draw(Textures.RightArrow, new Rectangle(320, 250, 64, 64), rightCol);
            spriteBatch.Draw(Textures.PlayerCircle, new Rectangle((int)tempPlayer.GetPosition().X, (int)tempPlayer.GetPosition().Y, (int)tempPlayer.GetSize().X, (int)tempPlayer.GetSize().Y), selectedClass.GetColor());
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
               ScreenManager.addScreen(new GameScreen(game));
            }

            //TODO or if I click on the left arrow?
            if (Input.KeyPressed(Keys.Left))
            {
                selectedClass = selectedClass.PrevValue();
                leftCol = Color.Red;
            }
            else if (Input.KeyPressed(Keys.Right))
            {
                selectedClass = selectedClass.NextValue();
                rightCol = Color.Red;
            }
            

            //Classes.charMap.TryGetValue(classSel, out tempClass);
            //selectedClass = tempClass;
        }

        private void resetInputs()
        {
            leftCol = Color.White;
            rightCol = Color.White;
        }

    }
}
