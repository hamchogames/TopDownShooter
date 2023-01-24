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
    public class BlinkEffect : Effect2d
    {

        public BlinkEffect(Vector2 POS, Vector2 DIMS, int MSEC) 
            : base("2d\\Effects\\Rez", POS, DIMS, new Vector2(4,1), MSEC)
        {
            frameAnimations = true;
            currentAnimation = 0;
            frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 4, 66, 0, "Base"));
            
        }

        public override void Update(Vector2 OFFSET)
        {
           
            base.Update(OFFSET);
        }
    }
}
