#region Includes
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
using TopDownShooterPrompt;
using System.Diagnostics;
#endregion


namespace TopDownShooter
{
    public class SpiderEggSac : SpawnPoint
    { 
        int maxSpawns, totalSpawns;
        public SpiderEggSac(Vector2 POS,Vector2 FRAMES, int OWNERID, XElement DATA) 
            : base("2d\\SpawnPoints\\EggSac", POS, new Vector2(45, 45), FRAMES, OWNERID, DATA)
        {
            totalSpawns = 0;
            maxSpawns = 3;
           


            health = 3;
            healthMax = health;
            spawnTimer = new McTimer(3000);
        }
        public override void Update(Vector2 OFFSET)
        {
           

            base.Update(OFFSET);
        }
        

        public override void SpawnMob()
        {

            Mob tempMob = new Spiderling(new Vector2(pos.X, pos.Y), new Vector2(1, 1), ownerId);

            if (tempMob != null)
            {

                GameGlobals.PassMob(tempMob);
                totalSpawns++;
                if(totalSpawns >= maxSpawns)
                {
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
