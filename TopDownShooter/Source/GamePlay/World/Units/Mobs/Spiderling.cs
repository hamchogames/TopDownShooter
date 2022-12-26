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
using TopDownShooterPrompt;
#endregion


namespace TopDownShooter
{
    public class Spiderling : Mob
    {
        public McTimer spawnTimer;
        public Spiderling(Vector2 POS, int OWNERID) : base("2d\\Units\\Mobs\\Spider", POS, new Vector2(25, 25), OWNERID)
        {

            speed = 2.5f;
   
        }
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
           
            base.Update(OFFSET, ENEMY);
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
