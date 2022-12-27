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
    public class Portal : SpawnPoint
    {

        public Portal(Vector2 POS, int OWNERID) : base("2d\\SpawnPoints\\Portal", POS, new Vector2(45, 45), OWNERID)
        {

            health = 15;
            healthMax = health;
        }
        public override void Update(Vector2 OFFSET)
        {
       

            base.Update(OFFSET);
        }


        public override void SpawnMob()
        {
            int num = Globals.rand.Next(0, 10 + 1);

            Mob tempMob = null;

            if (num < 5)
            {
                tempMob = new Imp(new Vector2(pos.X, pos.Y), ownerId);
                Debug.WriteLine("Spawn Imp");
            }
            else if (num < 8)
            {
                tempMob = new Spider(new Vector2(pos.X, pos.Y), ownerId);
                Debug.WriteLine("Spawn Spider");
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
