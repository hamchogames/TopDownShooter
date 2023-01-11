#region Includes
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
using SharpDX.Direct2D1;
#endregion


namespace TopDownShooter
{
    public class Spiderling : Mob
    {

        public Spiderling(Vector2 POS, Vector2 FRAMES, int OWNERID) : base("2d\\Units\\Mobs\\Spider", POS, new Vector2(25, 25), FRAMES, OWNERID)
        {

            speed = 2.5f;

        }
        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {

            base.Update(OFFSET, ENEMY, GRID);
        }

        public override void AI(Player ENEMY, SquareGrid GRID)
        {


            Building temp = null;
            for (int i = 0; i < ENEMY.buildings.Count; i++)
            {
                if (ENEMY.buildings[i].GetType().ToString() == "TopDownShooter.Tower")
                {
                    temp = ENEMY.buildings[i];

                }
            }

            if (temp != null)
            {

                if (pathNodes == null || (pathNodes.Count == 0 && pos.X == moveTo.X && pos.Y == moveTo.Y))
                {
                    pathNodes = FindPath(GRID, GRID.GetSlotFromPixel(temp.pos, Vector2.Zero));
                    moveTo = pathNodes[0];
                    pathNodes.RemoveAt(0);
                }
                else
                {
                    MoveUnit();

                    if (Globals.GetDistance(pos, temp.pos) < GRID.slotDims.X * 1.2f)
                    {
                        temp.GetHit(1);
                        dead = true;
                    }
                }

            }
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }

    
}
    

