﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
#endregion


namespace TopDownShooter
{
    public class Portal : SpawnPoint
    {

        public Portal(Vector2 POS, Vector2 FRAMES, int OWNERID,  XElement DATA) 
            : base("2d\\SpawnPoints\\Portal", POS, new Vector2(45, 45), FRAMES, OWNERID, DATA)
        {

            health = 15;
            healthMax = health;
        }
        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {
       

            base.Update(OFFSET, ENEMY, GRID);
        }


        public override void SpawnMob()
        {
            int num = Globals.rand.Next(0, 100 + 1);

            Mob tempMob = null;
            int total = 0;

            for (int i=0;i<mobChoices.Count; i++)
            {
                total += mobChoices[i].rate;
                if (num < total)
                {
                    
                        Type sType = Type.GetType("TopDownShooter." + mobChoices[i].mobStr, true);
                    tempMob = (Mob)(Activator.CreateInstance(sType, new Vector2(pos.X, pos.Y), new Vector2(1, 1), ownerId));


                    break;
                }
            }

            
           

            if (tempMob != null)
            {
                GameGlobals.PassMob(tempMob);
            }
            }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
