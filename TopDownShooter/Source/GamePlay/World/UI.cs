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
    public class UI
    {

        public Basic2d pauseOverlay;

        public Button2d resetBtn, skillMenuBtn;

        public SkillMenu skillMenu;

        public SpriteFont font;

        public QuantityDisplayBar healthBar;

        public UI(PassObject RESET, Hero HERO)
        {
            pauseOverlay = new Basic2d("2d\\Misc\\PauseOverlay", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(300, 300));

            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");

            resetBtn = new Button2d("2d\\Misc\\SimpleBtn", new Vector2(0, 0), new Vector2(96, 32), "Fonts\\Arial16", "Reset", RESET, null);
            skillMenuBtn = new Button2d("2d\\Misc\\SimpleBtn", new Vector2(0, 0), new Vector2(96, 32), "Fonts\\Arial16", "Skills", ToggleSkillMenu, null);

            skillMenu = new SkillMenu(HERO);

            healthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }

        public void Update(World WORLD)
        {
            healthBar.Update(WORLD.user.hero.health, WORLD.user.hero.healthMax);

            if (WORLD.user.hero.dead || WORLD.user.buildings.Count <= 0)
            {
                resetBtn.Update(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 100));

            }
            skillMenuBtn.Update(new Vector2(Globals.screenWidth - 100, Globals.screenHeight - 100));

            skillMenu.Update();
        }

        public virtual void ToggleSkillMenu(object INFO)
        {
            skillMenu.ToggleActive();
        }

        public void Draw(World WORLD)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            string tempStr = "Gold = " + WORLD.user.gold;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(40, 40), Color.Black);

            tempStr = "Score = " + GameGlobals.score;
            strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight - 40), Color.Black);

            if (WORLD.user.hero.dead || WORLD.user.buildings.Count <= 0)
            {
                tempStr = "Press Enter or click the button to Restart!";
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight / 2), Color.Black);

                resetBtn.Draw(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 100));

            }

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));
            skillMenuBtn.Draw(new Vector2(Globals.screenWidth - 100, Globals.screenHeight - 100));


            skillMenu.Draw();

            if (GameGlobals.paused)
            {
                pauseOverlay.Draw(Vector2.Zero);
            }
        }
    }
}
