﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace TopDownShooter
{
    public class UI
    {

        public SpriteFont font;
        public UI() 
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Lindsey20");
            
        
        }

        public void Update(World WORLD)
        {

        }

        public void Draw(World WORLD) 
        {
            string tempStr = "Num Killed" + WORLD.numKilled;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40) , Color.Black);
        }
    }
}