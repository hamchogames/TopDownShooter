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
    public class Hero : Unit
    {
        public string name;

        public SkillBar skillBar;
        public Hero(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID) : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            
            speed = 2.0f;

            name = "Zavix";

            health = 5;
            healthMax = health;

            frameAnimations = true;
            currentAnimation = 0;
            frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 4, 133, 0, "Walk"));
                frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 1, 133, 0, "Stand"));

            skills.Add(new FlameWave(this));
            skills.Add(new Blink(this));

            skillBar = new SkillBar(new Vector2(80, Globals.screenHeight - 80), 52, 10);

            for (int i=0; i<skills.Count; i++)
            {
                if( i<skillBar.slots.Count)
                {
                    skillBar.slots[i].skillButton = new SkillButon("2d\\Misc\\solid", new Vector2(0, 0), new Vector2(40, 40), SetSkill, skills[i]);


                }
                else
                {
                    break;
                }
            }
        }
        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID, LevelDrawManager LEVELDRAWMANAGER)
        {
            bool checkScoll = false;

            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - speed, pos.Y);
                checkScoll = true;
            }

            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + speed, pos.Y);
                checkScoll = true;
            }

            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - speed);
                checkScoll = true;
            }

            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + speed);
                checkScoll= true;
            }

            

           /* if (Globals.keyboard.GetSinglePress("D1"))
            {
                currentSkill = skills[0];
                currentSkill.Active = true;
               
            }

            if (Globals.keyboard.GetSinglePress("D2"))
            {
                currentSkill = skills[1];
                currentSkill.Active = true;

            }*/

            GameGlobals.CheckScroll(pos);

            if (checkScoll)
            {
                
                SetAnimationByName("Walk");
            }
            else
            {
                SetAnimationByName("Stand");
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET);



            if (currentSkill == null) {
                if (Globals.mouse.LeftClick())
                {

                    GameGlobals.PassProjectile(new Fireball(new Vector2(pos.X, pos.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET));
                    Globals.soundControl.PlaySound("Shoot");
                }
                
            }
            else
            {
                currentSkill.Update(OFFSET, ENEMY);

                if (currentSkill.done)
                {
                    currentSkill.Reset();
                    currentSkill = null;
                }
            }

            if (Globals.mouse.RightClick())
            {
                if (currentSkill != null)
                {
                    currentSkill.targetEffect.done = true;
                    currentSkill.Reset();
                    currentSkill = null;
                }
            }

            skillBar.Update(Vector2.Zero);
               

            base.Update(OFFSET, ENEMY, GRID, LEVELDRAWMANAGER);
        }

        public virtual void SetSkill(object INFO)
        {
           

            if (INFO != null) {

                SkillSelectionTypePacket tempPacket = (SkillSelectionTypePacket)INFO;

                currentSkill = tempPacket.skill;
                currentSkill.Active = true;
                currentSkill.selectionType = tempPacket.selectionType;
            }
        }

        
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);

            skillBar.Draw(Vector2.Zero);
        }
    }
}
