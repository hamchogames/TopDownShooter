#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Xml;
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
    public class FlameCircle : Effect2d
    {

        public FlameCircle(Vector2 POS, Vector2 DIMS) : base("2d\\Effects\\FireNova", POS, DIMS, new Vector2(1,1), 400)
        {

        }

        public override void Update(Vector2 OFFSET)
        {
            rot += (float)Math.PI * 2 / 60.0f;
            base.Update(OFFSET);
        }
    }
}
