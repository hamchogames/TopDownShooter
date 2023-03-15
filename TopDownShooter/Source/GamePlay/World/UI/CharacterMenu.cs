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
    public class CharacterMenu : Menu2d
    {
        public Hero hero;

        public TextZone textZone;
        public CharacterMenu(Hero HERO) 
            : base(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(350, 500), null)
        {
            hero= HERO;

            textZone = new TextZone(new Vector2(0, 0), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", (int)(dims.X * .9f), 22, "Fonts\\Arial16",Color.Gray);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();

            if(Active)
            {
                Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
                Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
                Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
                Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
                Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
                Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

                string tempStr = "" + hero.name;
                Vector2 strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, topLeft + new Vector2(bkg.dims.X/2 - strDims.X/2, 40), Color.Black);

                textZone.Draw(topLeft + new Vector2(10, 100));
            }
        }
    }
}
