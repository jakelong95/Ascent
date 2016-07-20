﻿using System;
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
			tempPlayer.SetSize(64, 64);
			tempPlayer.SetPosition(game.GraphicsDevice.Viewport.Width / 2 - (int)tempPlayer.GetSize().X / 2, game.GraphicsDevice.Viewport.Height / 2 - (int)tempPlayer.GetSize().Y /2);//TODO DEBUG REMOVE

			selectedClass = PlayerClass.Cleric;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
  
			Vector2 position = tempPlayer.GetPosition();
			Vector2 size = tempPlayer.GetSize();
			spriteBatch.Draw(Textures.PlayerCircle, new Rectangle((int) position.X, (int) position.Y, (int) size.X, (int) size.Y), selectedClass.GetColor());
			
		   	spriteBatch.Draw(Textures.LeftArrow, new Rectangle( (int)position.X - 80 , (int)position.Y, 64, 64), leftCol);
			spriteBatch.Draw(Textures.RightArrow, new Rectangle((int)position.X + 80, (int)position.Y, 64, 64), rightCol);


			spriteBatch.DrawString(Fonts.georgia16, "Character Selection Screen", new Vector2(Utilities.CenterTextX(Fonts.georgia16, "Character Creation Screen"), 10), Color.White);


			spriteBatch.DrawString(Fonts.centaur10, selectedClass.GetName(), new Vector2(Utilities.CenterTextX(Fonts.centaur10, selectedClass.GetName()), position.Y - 30), Color.White);
			spriteBatch.DrawString(Fonts.centaur10, selectedClass.GetDescription(), new Vector2(Utilities.CenterTextX(Fonts.centaur10, selectedClass.GetDescription()), position.Y + 80), Color.White);
				
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
