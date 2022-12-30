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
    public class Building : AttackableObject
    {

       
        public Building(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) 
            : base(PATH, POS, DIMS, OWNERID) 
        {
            
        }
        public virtual void Update(Vector2 OFFSET, Player ENEMY)
        {
           

            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {  /*Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xSize"].SetValue((float)(int)dims.X);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)(int)dims.Y);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();*/
            base.Draw(OFFSET);
        }
    }
}
