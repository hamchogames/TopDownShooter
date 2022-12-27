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
using System.Security.Cryptography.X509Certificates;
using SharpDX.Direct2D1.Effects;
using TopDownShooterPrompt;
#endregion

namespace TopDownShooter
{
    public class Projectile2d : Basic2d
    {
        public bool done;

        public float speed;

        public Vector2 direction;

        public Unit owner;

        public McTimer timer;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
        {
            done = false;

            speed = 5.0f;
            owner = OWNER;
            direction = TARGET - owner.pos;
            direction.Normalize();
            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

            timer = new McTimer(1500); //1.2sec
        }

      
            public virtual void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            pos += direction * speed;



            timer.UpdateTimer();
            if(timer.Test())
            {
                done = true;
            }

            if(HitSomething(UNITS))
            {

                done = true;

            }

        }


        public virtual bool HitSomething(List<AttackableObject> UNITS)
        {
            for(int i=0; i<UNITS.Count; i++)
            {
                if(owner.ownerId != UNITS[i].ownerId && Globals.GetDistance(pos, UNITS[i].pos)< UNITS[i].hitDist)
                {
                    UNITS[i].GetHit(1);
                    return true;
                }
            }
            return false;
        }


        public override void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xSize"].SetValue((float)(int)dims.X);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)(int)dims.Y);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();
            base.Draw(OFFSET);
        }

        }

    }

