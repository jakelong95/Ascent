using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Ascent.Resources;
using Ascent.ScreenManager;
using Microsoft.Xna.Framework.Graphics;

namespace Ascent.ScreenManager.Screens
{
    class GameScreen : BaseScreen
    {
        String coords;
        Vector2 destCoords;
        MouseState ms = Mouse.GetState();
        public GameScreen()
        {
            name = "GameScreen";
            state = ScreenState.Active;
            ms = Mouse.GetState();
        }
        
       

        public override void HandleInput()
        {
            //Debug switch to Direct Connect
            if (Input.KeyPressed(Keys.F7))
            {
                ScreenManager.unloadScreen(name);
                ScreenManager.addScreen(new DirectConnectScreen());
            }
        }

        public override void Update(float delta)
        {
            MouseState prevState = ms;
            ms = Mouse.GetState();
        if (ms.LeftButton == ButtonState.Pressed
            && prevState.LeftButton == ButtonState.Released){
            //But we forreal need to restruct this to the screen, and it would be nice if I could have my isactive back
           // && this.IsActive //We removed this. Can we have it back.
           // && ms.X >= 0 && ms.X < graphics.PreferredBackBufferWidth //Still don't konw how to access this.
         //   && ms.Y >= 0 && ms.Y < graphics.PreferredBackBufferHeight
           // && System.Windows.Forms.Form.ActiveForm != null
           // && System.Windows.Forms.Form.ActiveForm.Text.Equals(this.Window.Title)) {
           //Mouse was clicked and the form is active
                coords = "" + ms.X + ", " + ms.Y;
                destCoords = new Vector2(ms.X + CharacterSelectionScreen.tempPlayer.offset.X, ms.Y + CharacterSelectionScreen.tempPlayer.offset.Y);
          }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //TODO: How do I know screen size locations?
            spriteBatch.DrawString(Fonts.georgia16, "Game Screen", new Vector2(250, 10), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, "Coords: " + coords, new Vector2(250, 60), Color.White);

            spriteBatch.Draw(Textures.playerCircle, new Rectangle((int)CharacterSelectionScreen.tempPlayer.GetPosition().X, (int)CharacterSelectionScreen.tempPlayer.GetPosition().Y, (int)CharacterSelectionScreen.tempPlayer.GetSize().X, (int)CharacterSelectionScreen.tempPlayer.GetSize().Y), CharacterSelectionScreen.tempPlayer.playerClass.getColor());
            spriteBatch.End();
        }
    }
}
