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

enum PacketTypes
{
    LOGIN,
    MOVE,
    WORLDSTATE
}

namespace Ascent.ScreenManager.Screens
{
    //Much of this networking code was taken from other sources and modified.
    //I chose commenting over deletion as many of the concepts will apply to us.
    //We'll almost certainly want to change to unreliable, if nothing else.
    class MultiplayerHostScreen : BaseScreen
    {


        string dataReceived;
        string localIP;
        NetServer server;
        NetIncomingMessage inc; //Store and read msg
        DateTime time = DateTime.Now;
        TimeSpan timetopass = new TimeSpan(0, 0, 0, 0, 30); // Create timespan of 30ms
        bool connInit = false;
        string connected = "";

        public MultiplayerHostScreen()
        {
            name = "MultiplayerHostScreen";
            state = ScreenState.Active;
            findIP();
            MakeConnection();
        }

          public override void Update(float delta)
        {
              // Server.ReadMessage() Returns new messages, that have not yet been read.
                if ((inc = server.ReadMessage()) != null)
                {
                    if (!connInit && inc.MessageType != NetIncomingMessageType.DebugMessage)
                    {
                        //Intialize with OK message
                        NetOutgoingMessage outmsg = server.CreateMessage();
                        outmsg.Write((byte)PacketTypes.WORLDSTATE);
                        server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                        connInit = true;
                    }

                    switch (inc.MessageType)
                    {
                        // If incoming message is Request for connection approval
                        // This is the very first packet/message that is sent from client
                        // Here you can do new player initialisation stuff
                        case NetIncomingMessageType.ConnectionApproval:
                            
                            // Read the first byte of the packet
                            // ( Enums can be casted to bytes, so it can be used to make bytes human-readable )
                            if (inc.ReadByte() == (byte)PacketTypes.LOGIN)
                            {
                                inc.SenderConnection.Approve();
                                connected = "Connected successfully!";
								//TODO: add the other person's cahracter to our world.
								
                                // Create message, that can be written and sent
                                NetOutgoingMessage outmsg = server.CreateMessage();

                                // first we write byte
                                outmsg.Write((byte)PacketTypes.WORLDSTATE);
                                
                                // then int //This could be the character class for example
                                outmsg.Write(1);

                                // Writes all the properties of object to the packet
                                // outmsg.WriteAllProperties(ch);

                                // Send message/packet to all connections, in reliably order, channel 0
                                // Reliably means, that each packet arrives in same order they were sent. Its slower than unreliable, but easyest to understand
                                server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                            }

                            break;

                        // Data type is all messages manually sent from client
                        // ( Approval is automated process )
                        case NetIncomingMessageType.Data:

                            // Read first byte
                            if (inc.ReadByte() == (byte)PacketTypes.MOVE)
                            {
                                // Check who sent the message
                                // This way we know, what character belongs to message sender
                               // foreach (Character ch in GameWorldState)
                                    // If stored connection ( check approved message. We stored ip+port there, to character obj )
                                //Each player object can know the host IP, for easier tracking
                                    // Find the correct character
                                   // if (ch.Connection != inc.SenderConnection)
                                        //continue

                                    // Read next byte
                                    byte b = inc.ReadByte();
                                   //dataReceived += b.ToString();

                                   // char c = (char)inc.ReadByte();
                                   // dataReceived += c;    

                                    // Handle movement. This byte should correspond to some direction
                                        //We probably want to do this by giving the dest path and doing
                                        //pathfinding on our end. In theory, our PF algorithm should be pure
                                        //So it shouldn't lead to discrepancies?

                                    // Create new message
                                    NetOutgoingMessage outmsg = server.CreateMessage();

                                    // Write byte, that is type of world state
                                    outmsg.Write((byte)PacketTypes.WORLDSTATE);

                                    // Iterate throught all the players in game
                                    //foreach (Character ch2 in GameWorldState)
                                    //{
                                    //    // Write all the properties of object to message
                                    //    outmsg.WriteAllProperties(ch2);
                                    //}

                                    // Send messsage to clients ( All connections, in reliable order, channel 0)
                                    server.SendMessage(outmsg, server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                                    break;

                            }
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            // In case status changed
                            // It can be one of these
                            // NetConnectionStatus.Connected;
                            // NetConnectionStatus.Connecting;
                            // NetConnectionStatus.Disconnected;
                            // NetConnectionStatus.Disconnecting;
                            // NetConnectionStatus.None;

                            // NOTE: Disconnecting and Disconnected are not instant unless client is shutdown with disconnect()
                            Console.WriteLine(inc.SenderConnection.ToString() + " status changed. " + (NetConnectionStatus)inc.SenderConnection.Status);
                            if (inc.SenderConnection.Status == NetConnectionStatus.Disconnected || inc.SenderConnection.Status == NetConnectionStatus.Disconnecting)
                            {
                                // Find disconnected character and remove it
                                //foreach (Character cha in GameWorldState)
                                //{
                                //    if (cha.Connection == inc.SenderConnection)
                                //    {
                                //        GameWorldState.Remove(cha);
                                //        break;
                                //    }
                                //}
                            }
                            break;
                    }
                } // If New messages

                // if 30ms has passed
                if ((time + timetopass) < DateTime.Now)
                {
                    // If there is even 1 client
                    if (server.ConnectionsCount != 0)
                    {
                        // Create new message
                        NetOutgoingMessage outmsg = server.CreateMessage();

                        // Write byte
                        outmsg.Write((byte)PacketTypes.WORLDSTATE);

                        // Write Int
                       // outmsg.Write(GameWorldState.Count);


                        // Send messsage to clients ( All connections, in reliable order, channel 0)
                        server.SendMessage(outmsg, server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                    }
                    // Update current time
                    time = DateTime.Now;
                }
         }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.georgia16, "Connection Host Screen", new Vector2(250, 10), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, "Your IP address is: " + localIP, new Vector2(200, 200), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, "Data received: " + dataReceived, new Vector2(200, 350), Color.White);
            spriteBatch.DrawString(Fonts.georgia16, connected, new Vector2(230, 370), Color.White);
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
            server = new NetServer(config);
            server.Start();
        }

        

    }
}
