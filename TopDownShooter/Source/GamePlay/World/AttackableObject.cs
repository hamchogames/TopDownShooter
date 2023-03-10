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
#endregion


namespace TopDownShooter
{
    public class AttackableObject : SceneItem
    {

        public bool dead, throbing;

        public int ownerId, killValue;

        public float speed, hitDist, health, healthMax;

        public McTimer throbTimer = new McTimer(1000);
        public AttackableObject(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID) : base(PATH, POS, DIMS, FRAMES, new Vector2(1,1)) 
        {
            ownerId= OWNERID;
            dead = false;
            throbing = false;
            speed = 2.0f;

            health = 1;
            healthMax = health;

            killValue = 1;

            hitDist = 35.0f;
        }
        public virtual void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID, LevelDrawManager LEVELDRAWMANAGER)
        {
            if (throbing)
            {
                throbTimer.UpdateTimer();
                if (throbTimer.Test())
                {
                    throbing = false;
                    throbTimer.ResetToZero();
                }
            }

            base.Update(OFFSET, LEVELDRAWMANAGER);
        }
        public virtual void GetHit(AttackableObject ATTACKER, float DAMAGE)
        {
            health -= DAMAGE;
            throbing = true;
            throbTimer.ResetToZero();

            if (health <= 0)
            {
                dead = true;

                GameGlobals.PassGold(new PlayerValuePacket(ATTACKER.ownerId, killValue));
            }
            
        }

        public override void Draw(Vector2 OFFSET)
        {
            if(throbing) 
            {
                Globals.throbEffect.Parameters["SINLOC"].SetValue((float)Math.Sin(((float)throbTimer.Timer/(float)throbTimer.MSec + (float)Math.PI/2) * ((float)Math.PI * 3)));
                Globals.throbEffect.Parameters["filterColor"].SetValue(Color.Red.ToVector4());
                Globals.throbEffect.CurrentTechnique.Passes[0].Apply();
            }
            else { 
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();
            }

            base.Draw(OFFSET);
        }
    }
}
