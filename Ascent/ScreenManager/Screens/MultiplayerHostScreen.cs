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
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using Lidgren.Network;

namespace Ascent.ScreenManager.Screens
{
    class MultiplayerHostScreen : BaseScreen
    {
        string localIP;

        public MultiplayerHostScreen()
        {
            name = "MultiplayerHostScreen";
            state = ScreenState.Active;
            findIP();
            MakeConnection();
        }

          public override void Update(float delta)
        {
            base.Update(delta);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.georgia16, "Connection Host Screen", new Vector2(250, 10), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, "Your IP address is: " + localIP, new Vector2(200, 200), Color.White);
            //spriteBatch.Draw(gameWinScreen, new Rectangle(0, 0, Game1.GAME_SIZE_X, Game1.GAME_SIZE_Y), Color.White);

            spriteBatch.End();
        }

        public override void HandleInput()
        {
            if (Input.KeyPressed(Keys.F7))
            {
                ScreenManager.unloadScreen(name);
                ScreenManager.addScreen(new CharacterSelectionScreen());
            }
        }
        public void findIP()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("10.0.2.4", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
        }

        public void MakeConnection()
        {
            var config = new NetPeerConfiguration("Ascent") { Port = 12345 };
            var server = new NetServer(config);
            server.Start();
        }

        

    }
}
