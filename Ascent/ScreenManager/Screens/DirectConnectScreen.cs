using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Ascent
{
    class DirectConnectScreen : BaseScreen
    {
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
            spriteBatch.Draw(gameWinScreen, new Rectangle(0, 0, Game1.GAME_SIZE_X, Game1.GAME_SIZE_Y), Color.White);
            spriteBatch.End();
            base.Draw(spriteBatch);
        }
    }


    }
}
