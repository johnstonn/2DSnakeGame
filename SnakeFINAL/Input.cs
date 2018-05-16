using System.Collections;
using System.Windows.Forms;

namespace Snake
{
    public class Input
    {
            //Load list of available Keyboard buttons
        private static Hashtable keyTable = new Hashtable();
            //Check to see if a particular button is pressed (True = when a button is pressed)
        public static bool KeyPressed(Keys key)
            //Detect if a keyboard button is pressed (false not pressed, true when pressed)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool) keyTable[key];
        }
        public static void ChangeState(Keys key, bool state)
            //has the state changed? yes/no
        {
            keyTable[key] = state;
        }
    }
}
