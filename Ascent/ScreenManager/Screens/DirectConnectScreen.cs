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
    //Netowrking based on http://xnacoding.blogspot.com/2010/07/how-to-lidgren-network.html
    //And http://genericgamedev.com/tutorials/lidgren-network-an-introduction-to-networking-in-csharp-games/
    class DirectConnectScreen : BaseScreen
    {
        private string ip = "";
        NetClient client;
        bool connected = false;

        public DirectConnectScreen(Game game) : base(game)
        {
            Console.Out.WriteLine("Test");
            name = "DirectConnectScreen";
            state = ScreenState.Active;
        }

        public override void Update(float delta)
        {
            if(connected)
            {
                checkForMesage();
            }
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.georgia16, "Connection Client Screen", new Vector2(Utilities.CenterTextX(Fonts.georgia16, "Connection Client Screen"), 10), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, ip, new Vector2(200, 200), Color.White);
            //spriteBatch.Draw(gameWinScreen, new Rectangle(0, 0, Game1.GAME_SIZE_X, Game1.GAME_SIZE_Y), Color.White);
         //   if (connecting)
        //    {
          //      spriteBatch.DrawString(Fonts.georgia16, "Connecting", new Vector2(200, 400), Color.White);
          //  }
            spriteBatch.End();
        }

        public override void HandleInput()
        {
          //  if (!connecting)
            {
                //Debug switch to character selection
                if (Input.KeyPressed(Keys.F7))
                {
                    ScreenManager.unloadScreen(name);
                    ScreenManager.addScreen(new MultiplayerHostScreen(game));
                }
                if (Input.KeyPressed(Keys.Back))
                {
                    ip = "";
                }
                ip += Input.keysEntered();
                if (Input.KeyPressed(Keys.Enter))
                {
                   makeConnection();
                }
            }

        }

        //The amount of error checking here is approximately none.
        public void makeConnection()
        {
            var config = new NetPeerConfiguration("Ascent");
            client = new NetClient(config);
            client.Start();
            client.Connect(ip, 12345);
            connected = true;
        }

       public void checkForMesage()
       {
            NetIncomingMessage message;
            while ((message = client.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        // handle custom messages
                        var data = message.ReadByte();//Do something with this
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        // handle connection status messages
                        switch(message.SenderConnection.Status)
                        {
                            /* .. */
                        }
                        break;

                    case NetIncomingMessageType.DebugMessage:
                        // handle debug messages
                        // (only received when compiled in DEBUG mode)
                        Console.WriteLine(message.ReadString());
                        break;

                    /* .. */
                    default:
                        Console.WriteLine("unhandled message with type: "
                            + message.MessageType);
                        break;
                }
            }
        }

    }
}