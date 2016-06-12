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
        bool connecting = false;
        NetClient client;
        bool readyConnect = false;

        public DirectConnectScreen()
        {
            name = "DirectConnectScreen";
            state = ScreenState.Active;
        }

        public override void Update(float delta)
        {
            if (readyConnect)
            {
                GetInputAndSendItToServer();
                CheckServerMessages();
            }
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.georgia16, "Connection Client Screen", new Vector2(250, 10), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, ip, new Vector2(200, 200), Color.White);
            //spriteBatch.Draw(gameWinScreen, new Rectangle(0, 0, Game1.GAME_SIZE_X, Game1.GAME_SIZE_Y), Color.White);
            if (connecting)
            {
                spriteBatch.DrawString(Fonts.georgia16, "Connecting", new Vector2(200, 400), Color.White);
            }
            spriteBatch.End();
        }

        public override void HandleInput()
        {
            if (!connecting)
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
                if (Input.KeyPressed(Keys.Enter))
                {
                    makeConnection();
                }
            }

        }

        //The amount of error checking here is approximately none.
        public void makeConnection()
        {
            readyConnect = true;
            connecting = true;
            var config = new NetPeerConfiguration("Ascent");
            client = new NetClient(config);
            NetOutgoingMessage outmsg = client.CreateMessage();

            client.Start();
            outmsg.Write((byte)PacketTypes.LOGIN);
            //outmsg.Write("Connection Test");

            client.Connect(ip, 12345, outmsg);


            // Funtion that waits for connection approval info from server
            WaitForStartingInfo();

        }


        // Before main looping starts, we loop here and wait for approval message
        private void WaitForStartingInfo()
        {
            // When this is set to true, we are approved and ready to go
            bool CanStart = false;

            // New incomgin message
            NetIncomingMessage inc;

            // Loop untill we are approved
            while (!CanStart)
            {
                // If new messages arrived
                if ((inc = client.ReadMessage()) != null)
                {
                    // Switch based on the message types
                    switch (inc.MessageType)
                    {
                        // All manually sent messages are type of "Data"
                        case NetIncomingMessageType.Data:

                            // Read the first byte
                            // This way we can separate packets from each others
                            if (inc.ReadByte() == (byte)PacketTypes.WORLDSTATE)
                            {

                                // Empty the gamestatelist
                                // new data is coming, so everything we knew on last frame, does not count here
                                // Even if client would manipulate this list ( hack ), it wont matter, becouse server handles the real list
                                //GameStateList.Clear();

                                int count = 0;

                                // Read int
                                //count = inc.ReadInt32();
                                //IT IS IMPERITIVE THAT OUR READS MATCH OUR WRITES.

                                //We'll need to develop our own protocol here.
                                //It seems like they send a WORLDSTATE byte, 
                                //Followed by the number of players, Then the
                                //Player data, and delete and re-create The
                                //Players every frame. Which is... a decision.

                                // Iterate all players
                                for (int i = 0; i < count; i++)
                                {
                                    // Create new character to hold the data
                                    //Character ch = new Character();

                                    // Read all properties ( Server writes characters all props, so now we can read em here. Easy )
                                    //inc.ReadAllProperties(ch);

                                    // Add it to list
                                    //  GameStateList.Add(ch);
                                }

                                //Wait no, they jsut do this initially. Disregard previous
                                //Vaguely judgey comment. This is ON connect. Not sure how
                                //We'd handle drop in / drop out at the moment, but this
                                //Is a good initialization step.
                                // When all players are added to list, start the game
                                CanStart = true;
                            }
                            break;
                    }
                }
            }
        }

        private void CheckServerMessages()
        {
            // Create new incoming message holder
            NetIncomingMessage inc;

            // While theres new messages
            //
            // THIS is exactly the same as in WaitForStartingInfo() function
            // Check if its Data message
            // If its WorldState, read all the characters to list
            while ((inc = client.ReadMessage()) != null)
            {
                if (inc.MessageType == NetIncomingMessageType.Data)
                {
                    if (inc.ReadByte() == (byte)PacketTypes.WORLDSTATE)
                    {
                        //GameStateList.Clear();
                        int jii = 0;
                        jii = inc.ReadInt32();
                        for (int i = 0; i < jii; i++)
                        {
                         //   Character ch = new Character();
                         //   inc.ReadAllProperties(ch);
                         //   GameStateList.Add(ch);
                        }
                    }
                }
            }
        }

        // Get input from player and send it to server
        private void GetInputAndSendItToServer()
        {

            // Readkey ( NOTE: This normally stops the code flow. Thats why we have timer running, that gets updates)
            // ( Timers run in different threads, so that can be run, even though we sit here and wait for input )
            //Except I got rid of the timer. So can we async this or move it to a different thread?
            //ConsoleKeyInfo kinfo = Console.ReadKey();

           // if (kinfo.KeyChar == 'q')
            {

                // Disconnect and give the reason
                client.Disconnect("Client received disconnect signal from server");

            }

            // If button was pressed and it was one of those movement keys
            //if (MoveDir != MoveDirection.NONE)
            //{
            //    // Create new message
                NetOutgoingMessage outmsg = client.CreateMessage();

                //outmsg.Write((byte)'a');
                // Write byte = Set "MOVE" as packet type
              //  outmsg.Write((byte)PacketTypes.MOVE);

                // Write byte = move direction
             //   outmsg.Write((byte)MoveDir);

                // Send it to server
                client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);

                // Reset movedir
                //MoveDir = MoveDirection.NONE;
            }

    }
}