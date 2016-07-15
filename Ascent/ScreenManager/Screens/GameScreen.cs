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
        string coords;
        Vector2 destCoords;
        MouseState ms = Mouse.GetState();
        public GameScreen(Game game) : base(game)
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
                ScreenManager.addScreen(new DirectConnectScreen(game));
            }
        }

        public override void Update(float delta)
        {
            MouseState prevState = ms;
            ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && prevState.LeftButton == ButtonState.Released && game.IsActive)
            {
                //Mouse was clicked and the form is active
                coords = "" + ms.X + ", " + ms.Y;
                destCoords = new Vector2(ms.X + CharacterSelectionScreen.tempPlayer.CenterOffset.X, ms.Y + CharacterSelectionScreen.tempPlayer.CenterOffset.Y);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //TODO: How do I know screen size locations?
            //game.GraphicsDevice.Viewport.Width/Height
            spriteBatch.DrawString(Fonts.georgia16, "Game Screen", new Vector2(250, 10), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, "Coords: " + coords, new Vector2(250, 60), Color.White);

            //spriteBatch.Draw(Textures.playerCircle, new Rectangle((int)CharacterSelectionScreen.tempPlayer.GetPosition().X, (int)CharacterSelectionScreen.tempPlayer.GetPosition().Y, (int)CharacterSelectionScreen.tempPlayer.GetSize().X, (int)CharacterSelectionScreen.tempPlayer.GetSize().Y), CharacterSelectionScreen.tempPlayer.playerClass.getColor());
            spriteBatch.End();
        }
    }
}
