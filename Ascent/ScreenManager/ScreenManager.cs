using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

enum ScreenState { Active, Shutdown, Hidden }

    
    class ScreenManager
    {
        public static List<BaseScreen> screens = new List<BaseScreen>();
        //Used so we can remove without affecting index numbers
        private static List<BaseScreen> newScreens = new List<BaseScreen>();


        public void Update(float delta)
        {
            //Generate list of dead screens for removal
            List<BaseScreen> removeScreens = new List<BaseScreen>();

            foreach(BaseScreen foundScreen in screens)
            {
                if (foundScreen.state == ScreenState.Shutdown)
                {
                    removeScreens.Add(foundScreen);
                }
                else
                {
                    foundScreen.focused = false;
                }
            }

            //Remove using a second list so we don't go out of bounds after deleting one.
            foreach (BaseScreen foundScreen in removeScreens)
            {
                screens.Remove(foundScreen);
            }

            //Add new screens to manager list
            foreach (BaseScreen foundScreen in newScreens)
            {
                screens.Add(foundScreen);
            }
            newScreens.Clear();

   
            //Figure out which screen to focus.
            for (int i = screens.Count - 1; i >= 0; i--)
            {
                if (screens[i].grabFocus)
                {
                    screens[i].focused = true;
                    break;
                }
            }

            //And then process that screen appropriately.
            foreach (BaseScreen foundScreen in screens)
            {
                //We can have multiple screens at once.
               // if(Globals.windowFocused)//TODO find way to check focus.
                {
                    foundScreen.HandleInput();
                }
                foundScreen.Update(delta);//Update no matter what
            }
            return;
        }//Update

        public void Draw(SpriteBatch spritebatch)
        {
            foreach(BaseScreen foundScreen in screens)
            {
                if (foundScreen.state == ScreenState.Active)
                {
                    foundScreen.Draw(spritebatch);
                }
            }
            return;
        }

        public static void addScreen(BaseScreen screen)
        {
            newScreens.Add(screen);
            return;
        }

        public static void unloadScreen(string screen)
        {
            foreach (BaseScreen foundScreen in screens)
            {
                if (foundScreen.name.Equals(screen))
                {
                    foundScreen.Unload();
                    return;
                }
            }
            return;
        }


    }
