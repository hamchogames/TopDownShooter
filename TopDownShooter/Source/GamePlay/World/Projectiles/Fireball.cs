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
#endregion

namespace TopDownShooter
{
    public class Fireball : Projectile2d
    {

        public Fireball(Vector2 POS, Unit OWNER, Vector2 TARGET) : base("2d\\Projectiles\\Fireball", POS, new Vector2(20, 20), OWNER, TARGET)
        {
  
        }

        public override void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
    
            base.Update(OFFSET, UNITS);
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

        }

    }

