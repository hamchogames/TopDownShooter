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
#endregion

namespace TopDownShooter
{
    public class OakTree : SceneItem
    {
      

        public OakTree(Vector2 POS, Vector2 SCALE) 
            : base("2d\\UI\\Scene\\OakTree", POS, new Vector2(100,100) * SCALE, new Vector2(1,1), SCALE)
        {
         
        }

        public override void Draw(Vector2 OFFSET)
        {
                Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
                Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
                Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
                Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
                Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
                Globals.normalEffect.CurrentTechnique.Passes[0].Apply();
        

            base.Draw(OFFSET);
        }
    


}
}
