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
		DateTime time = DateTime.Now;
		TimeSpan timetopass = new TimeSpan(0, 0, 0, 0, 30); // Create timespan of 30ms
		bool connInit = false;
		string connected = "";

		public MultiplayerHostScreen(Game game) : base(game)
		{
			name = "MultiplayerHostScreen";
			state = ScreenState.Active;
			findIP();
			MakeConnection();
		}

		  public override void Update(float delta)
		  {
			 checkForMessages();
		  }

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.DrawString(Fonts.georgia16, "Connection Host Screen", new Vector2(Utilities.CenterTextX(Fonts.georgia16, "Connection Host Screen"), 10), Color.White);
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
				ScreenManager.addScreen(new CharacterSelectionScreen(game));
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
		    NetPeerConfiguration config = new NetPeerConfiguration("Ascent") { Port = 12345 };
			config.EnableMessageType(NetIncomingMessageType.DiscoveryRequest);
			server = new NetServer(config);
			server.Start();
		}

	   public void checkForMessages()
	   {
		  NetIncomingMessage msg;
		  while ((msg = server.ReadMessage()) != null)
		  {
			 switch (msg.MessageType) 
			 { 
			    case NetIncomingMessageType.DiscoveryRequest:
				  // Create a response and write some example data to it
				  NetOutgoingMessage response = server.CreateMessage();
				  response.Write("Ascent Server");
				  Console.Out.Write("connected");
				  // Send the response to the sender of the request
				  server.SendDiscoveryResponse(response, msg.SenderEndPoint);
				  break;
				case NetIncomingMessageType.VerboseDebugMessage:
				case NetIncomingMessageType.DebugMessage:
				case NetIncomingMessageType.WarningMessage:
				case NetIncomingMessageType.ErrorMessage:
				  Console.WriteLine(msg.ReadString());
				  break; 
			   default: 
				  Console.WriteLine("Unhandled type: " + msg.MessageType);
				  break; 
			 }
			 server.Recycle(msg); 
		  }
		}

	   //Just an example
	   //public void sendMessage()
	   //{
	   //   NetOutgoingMessage sendMsg = server.CreateMessage();
	   //   sendMsg.Write("Hello");
	   //   sendMsg.Write(42);
	   //   server.SendMessage(sendMsg, recipient, NetDeliveryMethod.ReliableOrdered);


	   //   //To read / decode this message:
	   //   //NetIncomingMessage incMsg = server.ReadMessage();
	   //   //string str = incMsg.ReadString();
	   //   //int a = incMsg.ReadInt32();
	   //}
	}
}
