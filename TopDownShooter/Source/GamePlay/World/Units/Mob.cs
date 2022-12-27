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
#endregion


namespace TopDownShooter
{
    public class Mob : Unit
    {
     
        public Mob(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {

            speed = 2.0f;

        }
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            AI(ENEMY);

            base.Update(OFFSET);
        }
        public virtual void AI(Player ENEMY)
        {
            pos += Globals.RadialMovement(ENEMY.hero.pos, pos, speed);
            rot = Globals.RotateTowards(pos, ENEMY.hero.pos);


            if (Globals.GetDistance(pos, ENEMY.hero.pos)< 15)
            {
                ENEMY.hero.GetHit(1);
                dead = true;
            }

        }

        

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
