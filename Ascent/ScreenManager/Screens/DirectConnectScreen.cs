using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ascent.ScreenManager;
using Microsoft.Xna.Framework.Input;
using Ascent.Resources;
using Lidgren.Network;

namespace Ascent.ScreenManager.Screens
{
    class DirectConnectScreen : BaseScreen
    {
        private string ip = "";
        bool connecting = false;

        public DirectConnectScreen()
        {
            name = "DirectConnectScreen";
            state = ScreenState.Active;
        }

          public override void Update(float delta)
        {

            base.Update(delta);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.georgia16, "Connection Client Screen", new Vector2(250, 10), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, ip, new Vector2(200, 200), Color.White);
            //spriteBatch.Draw(gameWinScreen, new Rectangle(0, 0, Game1.GAME_SIZE_X, Game1.GAME_SIZE_Y), Color.White);
            if(connecting)
            {
                spriteBatch.DrawString(Fonts.georgia16, "Connecting", new Vector2(200, 400), Color.White);
            }
            spriteBatch.End();
        }

        public override void HandleInput()
        {
            if(!connecting)
            {
                //Debug switch to character selection
                if (Input.KeyPressed(Keys.F7))
                {
                    ScreenManager.unloadScreen(name);
                    ScreenManager.addScreen(new MultiplayerHostScreen());
                }
                if (Input.KeyPressed(Keys.Back))
                {
                    ip = "";
                }
                ip += Input.keysEntered();
                if(Input.KeyPressed(Keys.Enter))
                {
                    makeConnection();
                }
            }

        }
        public void makeConnection()
        {
            connecting = true;
            var config = new NetPeerConfiguration("Ascent");
            var client = new NetClient(config);
            client.Start();
            client.Connect(host: ip, port: 12345);
        }
    }
}
