using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Input
{
    //Keyboard
    static KeyboardState currentKeyState;
    static KeyboardState lastKeyState;

    public static void Update()
    {
        //Current to old
        lastKeyState = currentKeyState;

        //New to current
        currentKeyState = Keyboard.GetState();
    }

    public static Boolean KeyDown(Keys key)
    {
        return currentKeyState.IsKeyDown(key);
    }

    public static Boolean KeyPressed(Keys key)
    {
        if (currentKeyState.IsKeyDown(key) && lastKeyState.IsKeyUp(key))
        {
            return true;
        }
        return false;
    }

}
