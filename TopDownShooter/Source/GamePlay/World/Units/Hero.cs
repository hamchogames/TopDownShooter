﻿#region Includes
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using TopDownShooterPrompt;
#endregion


namespace TopDownShooter
{
    public class Hero : Unit
    {
     
        public Hero(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID) : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            
            speed = 2.0f;

            health = 5;
            healthMax = health;

            frameAnimations = true;
            currentAnimation = 0;
            frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 4, 133, 0, "Walk"));
                frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 1, 133, 0, "Stand"));

        }
        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {
            bool checkScoll = false;

            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - speed, pos.Y);
                checkScoll = true;
            }

            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + speed, pos.Y);
                checkScoll = true;
            }

            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - speed);
                checkScoll = true;
            }

            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + speed);
                checkScoll= true;
            }

            if (Globals.keyboard.GetSinglePress("D1"))
            {
                Vector2 tempLoc = GRID.GetSlotFromPixel(new Vector2(pos.X, pos.Y - 30), Vector2.Zero);
                GridLocation loc = GRID.GetSlotFromLocation(tempLoc);

                if (loc != null && !loc.filled && !loc.impassable)
                {
                    loc.SetToFilled(false);
                    Building tempBuilding = new ArrowTower(new Vector2(pos.X, pos.Y - 30), new Vector2(1, 1), ownerId);
                    tempBuilding.pos = GRID.GetPosFromLoc(tempLoc) + GRID.slotDims/2;
                    GameGlobals.PassBuilding(tempBuilding);
                }

              
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET);

            if (Globals.mouse.LeftClick())
            {
                
                GameGlobals.PassProjectile(new Fireball(new Vector2(pos.X, pos.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET));
                
            }
            if (checkScoll)
            {
                GameGlobals.CheckScroll(pos);
                SetAnimationByName("Walk");
            }
            else
            {
                SetAnimationByName("Stand");
            }

            base.Update(OFFSET, ENEMY, GRID);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
