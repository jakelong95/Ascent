using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

    class TitleScreen : BaseScreen
    {
        public TitleScreen()
        {
            name = "TitleScreen";
            state = ScreenState.Active;
        }

        public override void Draw()
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(Textures.blackGradient, new Rectangle(0, 0, (int)Globals.gameSize.X, (int)Globals.gameSize.Y), new Rectangle(0, 0, 64, 3), Color.Turquoise);
            Globals.spriteBatch.DrawString(Fonts.Georgia_16, "ASTEROIDS!", new Vector2(Globals.gameSize.X / 2 - Fonts.Georgia_16.MeasureString("ASTEROIDS!").X, Globals.gameSize.Y / 5), Microsoft.Xna.Framework.Color.Black, 0, new Vector2(0, 0), 2, SpriteEffects.None,0);
            Globals.spriteBatch.DrawString(Fonts.Centaur_10, "But like, with snow", new Vector2(Globals.gameSize.X / 2 - Fonts.Centaur_10.MeasureString("But like, with snow").X, Globals.gameSize.Y / 5 + 40.0f), Microsoft.Xna.Framework.Color.Black, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            Globals.spriteBatch.DrawString(Fonts.Centaur_10, "Press A (controller) or Enter (Keyboard) to begin", new Vector2(Globals.gameSize.X / 2 - Fonts.Centaur_10.MeasureString("Press A (controller) or Enter (Keyboard) to begin").X, Globals.gameSize.Y - (float)140.0), Microsoft.Xna.Framework.Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            //Globals.spriteBatch.DrawString(Fonts.Centaur_10, "Hold tab or left bumper at any time to see controls.", new Vector2(Globals.gameSize.X / 2 - Fonts.Centaur_10.MeasureString("Hold tab or left bumper at any time to see controls.").X, Globals.gameSize.Y - (float)110.0), Microsoft.Xna.Framework.Color.White, 0, new Vector2(0, 0),1, SpriteEffects.None, 0);

            Globals.spriteBatch.DrawString(Fonts.Centaur_10, "Hold tab or left bumper at any time to see controls.", new Vector2(Globals.gameSize.X / 2 - Fonts.Centaur_10.MeasureString("Hold tab or left bumper at any time to see controls.").X, Globals.gameSize.Y - (float)110.0), Microsoft.Xna.Framework.Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);

            //TODO switch back to 3D mode?
            Globals.spriteBatch.End();
            return;
        }

        public override void HandleInput()
        {
            if(Input.keyPressed(Keys.Enter) || Input.buttonPressed(Buttons.A, PlayerIndex.One) || Input.buttonPressed(Buttons.Start, PlayerIndex.One))
            {
                ScreenManager.unloadScreen("TitleScreen");
                ScreenManager.addScreen(new MainMenu());
            }
        }
        
    }
