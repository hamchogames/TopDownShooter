#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace TopDownShooter
{
    public class McKeyboard
    {

        public KeyboardState newKeyboard, oldKeyboard; // keeping track of previous and current pressed key

        public List<McKey> pressedKeys = new List<McKey>(), previousPressedKeys = new List<McKey>();

        public McKeyboard()
        {

        }

        public virtual void Update()
        {
            newKeyboard = Keyboard.GetState();

            GetPressedKeys();

        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<McKey>();
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string KEY)
        {

            for (int i = 0; i < pressedKeys.Count; i++)
            {

                if (pressedKeys[i].key == KEY)
                {
                    return true;
                }

            }


            return false;
        }


        public virtual void GetPressedKeys()
        {
            bool found = false;

            pressedKeys.Clear();
            for (int i = 0; i < newKeyboard.GetPressedKeys().Length; i++)
            {

                pressedKeys.Add(new McKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));

            }
        }

        public bool GetSinglePress(string KEY)
        {
            for(int i=0;i<pressedKeys.Count;i++)
            {
                bool isIN = false;
                for(int j=0;previousPressedKeys.Count>j;j++)
                {
                    if (pressedKeys[i].key == previousPressedKeys[j].key) 
                    { 
                        isIN = true;
                        break;
                    }

                }
                if (!isIN && (pressedKeys[i].key == KEY || pressedKeys[i].print == KEY))
                    {
                    return true;
                }

            }
            return false;
        }

    }
}