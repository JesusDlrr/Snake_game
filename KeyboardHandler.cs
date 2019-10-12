using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace netetst
{
    public enum KeyCode : int {
        Left = 0x25,
        Up = 0x26,
        Right = 0x27,
        Down = 0x28,
        Enter = 0xD,
        Scape = 0x1B
    }

    public class KeyboardHandler
    {
        [DllImport("User32.dll")]
        public static extern short GetKeyState(int keycode);

        public static bool pressed = false;

        public static bool isPressed(KeyCode key) {
            return (GetKeyState((int)key) & 0x8000) != 0;
        }
        public static bool onKeyDown(KeyCode key) {
            //pressed = false;
            /*if (isPressed(key))
            {
                if (!pressed)
                {
                    pressed = true;
                    return true;
                }
            }*/

            return false;
        }
    }
}
