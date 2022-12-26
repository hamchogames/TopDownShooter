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

        public QuantityDisplayBar healthBar;
        public UI() 
        {
            font = Globals.content.Load<SpriteFont>("Fonts//Arial16");

            healthBar = new QuantityDisplayBar(new Vector2(104,16),2,Color.Red);
        }

        public void Update(World WORLD)
        {
            healthBar.Update(WORLD.user.hero.health, WORLD.user.hero.healthMax);
        }

        public void Draw(World WORLD) 
        {
            string tempStr = "Score " + GameGlobals.score;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40) , Color.Black);

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 20));


            if (WORLD.user.hero.dead)
            {
                tempStr = "Press Enter to Restart!";
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight/2), Color.Black);
            }
        }
    }
}
