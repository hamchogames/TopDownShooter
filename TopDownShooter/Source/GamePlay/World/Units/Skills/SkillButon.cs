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
using SharpDX.MediaFoundation;
#endregion

namespace TopDownShooter
{
    public class SkillButon : Button2d
    {
        public Vector2 lastOffset;

        public Skill skill;

        public SkillButtonSlot slot;


        public SkillButon(string PATH, Vector2 POS, Vector2 DIMS, PassObject BUTTONCLICKED, object INFO)
            : base(PATH, POS, DIMS,"","", BUTTONCLICKED, INFO)
        {
            skill = (Skill)INFO;
            slot = null;
        }

        public override void Update(Vector2 OFFSET)
        {
            lastOffset = OFFSET;

            if (skill != null) 
            { 

            base.Update(OFFSET);
            }
        }

        public override void RunBtnClick()
        {
            if (ButtonClicked != null)
            {
                SkillSelectionTypePacket tempPacket = new SkillSelectionTypePacket(1,(Skill)info);
                if (Hover(lastOffset))
                {
                    tempPacket.selectionType = 0;
                }
                    ButtonClicked(tempPacket);
            }

            Reset();
        }



        public override void Draw(Vector2 OFFSET)
        {
           

            base.Draw(OFFSET);

            if(skill != null)
            {
                skill.icon.Draw(OFFSET);
            }
           
        }
    }
}
