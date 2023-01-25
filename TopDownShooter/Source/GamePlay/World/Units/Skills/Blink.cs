﻿#region Includes
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

    public class Blink : Skill
    {

        public Blink(AttackableObject OWNER) : base(OWNER) 
        {
            icon = new Animated2d("2d\\UI\\Icons\\Skills\\Blink", new Vector2(0,0), new Vector2(40,40), new Vector2(1,1), Color.White);
        }

        public override void Targeting(Vector2 OFFSET, Player ENEMY)
        {

           

            GameGlobals.PassEffect(new BlinkEffect(Globals.mouse.newMousePos - OFFSET, new Vector2(owner.dims.X, owner.dims.Y), 266));

            GameGlobals.PassEffect(new BlinkEffect(new Vector2(owner.pos.X, owner.pos.Y), new Vector2(owner.dims.X, owner.dims.Y), 266));

            owner.pos = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET;

            done = true;
            active = false;

        }

    }
}
