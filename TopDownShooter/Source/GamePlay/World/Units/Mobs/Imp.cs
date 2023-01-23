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
#endregion


namespace TopDownShooter
{
    public class Imp : Mob
    {

        public Imp(Vector2 POS, Vector2 FRAMES, int OWNERID) : base("2d\\Units\\Mobs\\Imp", POS, new Vector2(40, 40), FRAMES, OWNERID)
        {

            speed = 2.0f;

        }
        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID, LevelDrawManager LEVELDRAWMANAGER)
        {
            
            base.Update(OFFSET, ENEMY, GRID, LEVELDRAWMANAGER);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
