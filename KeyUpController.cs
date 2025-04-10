using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace tetris;

public static class KeyUpController
{
    static Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

    public static bool HasKeyReleased(Keys key)
    {
        _pressedKeys.TryAdd(key, false);

        if (Keyboard.GetState().IsKeyDown(key))
        {
            _pressedKeys[key] = true;
            return false;
        }
        
        if (_pressedKeys[key] == true)
        {
            _pressedKeys[key] = false;
            return true;
        }

        return false;
    }
}