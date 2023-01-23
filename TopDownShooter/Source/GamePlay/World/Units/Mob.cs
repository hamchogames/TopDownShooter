﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Xml;
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
    public class Mob : Unit
    {
        public bool currentlyPathing, isAttacking;

        public float attackRange;

        public McTimer rePathTimer = new McTimer(200), attackTimer = new McTimer(350);
        public Mob(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID) : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            attackRange = 50;

            isAttacking = false;
            currentlyPathing = false;
            speed = 2.0f;

        }
        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {
            AI(ENEMY, GRID);

            base.Update(OFFSET, ENEMY, GRID);
        }
        public virtual void AI(Player ENEMY, SquareGrid GRID)
        {

            rePathTimer.UpdateTimer();

            if (pathNodes == null || (pathNodes.Count == 0 && pos.X == moveTo.X && pos.Y == moveTo.Y) || rePathTimer.Test())
            {
                if (!currentlyPathing)
                {
                    Task repathTask = new Task(() =>
                    { 
                        currentlyPathing = true;
                    pathNodes = FindPath(GRID, GRID.GetSlotFromPixel(ENEMY.hero.pos, Vector2.Zero));
                    moveTo = pathNodes[0];
                    pathNodes.RemoveAt(0);

                    rePathTimer.ResetToZero();

                    currentlyPathing = false;
                });
                repathTask.Start();
                }
            }
            else
            {
                MoveUnit();

                if (Globals.GetDistance(pos, ENEMY.hero.pos) < GRID.slotDims.X * 1.2f)
                {
                    ENEMY.hero.GetHit(this, 1);
                    dead = true;
                }
            }

        }

       



        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
