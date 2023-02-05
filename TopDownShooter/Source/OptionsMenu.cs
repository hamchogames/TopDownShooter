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
    public class OptionsMenu
    {
        Button2d exitBtn;

        public List<ArrowSelector> arrowSelectors = new List<ArrowSelector>();

        SpriteFont font;

        public OptionsMenu() 
        {
            exitBtn = new Button2d("2d\\Misc\\SimpleBtn", new Vector2(Globals.screenWidth / 2, Globals.screenHeight - 100), new Vector2(96, 32), "Fonts\\Arial16", "Exit", ExitClick, null);

            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");
            arrowSelectors.Add(new ArrowSelector(new Vector2(Globals.screenWidth/2, 300), new Vector2(128,32) , "Full Screen"));
            arrowSelectors[arrowSelectors.Count - 1].AddOption(new FormOption("No", 0));
            arrowSelectors[arrowSelectors.Count - 1].AddOption(new FormOption("Yes", 1));

            arrowSelectors.Add(new ArrowSelector(new Vector2(Globals.screenWidth / 2, 400), new Vector2(128, 32), "Music Volume"));
            for (int i = 0; i<31; i++)
            {
                arrowSelectors[arrowSelectors.Count - 1].AddOption(new FormOption(""+ i, i));
            }
            arrowSelectors[arrowSelectors.Count - 1].selected = (int)(arrowSelectors[arrowSelectors.Count - 1].options.Count / 2);
            arrowSelectors.Add(new ArrowSelector(new Vector2(Globals.screenWidth / 2, 500), new Vector2(128, 32), "Sound Volume"));
            for (int i = 0; i < 31; i++)
            {
                arrowSelectors[arrowSelectors.Count - 1].AddOption(new FormOption("" + i, i));
            }
            arrowSelectors[arrowSelectors.Count - 1].selected = (int)(arrowSelectors[arrowSelectors.Count - 1].options.Count / 2);
        }

        public virtual void Update()
        {
            for(int i = 0; i< arrowSelectors.Count; i++)
            {
                arrowSelectors[i].Update(Vector2.Zero);
            }
            exitBtn.Update(Vector2.Zero);
        }

        public virtual void ExitClick(object INFO)
        {
            Globals.gameState = 0;
        }

        public virtual void Draw()
        {

            Vector2 strDims = font.MeasureString("Options");

            Globals.spriteBatch.DrawString(font, "Options", new Vector2(Globals.screenWidth / 2 - strDims.X / 2, 100), Color.White);

            exitBtn.Draw(Vector2.Zero);

            for (int i = 0; i < arrowSelectors.Count; i++)
            {
                arrowSelectors[i].Draw(Vector2.Zero, font);
            }

        }
    }
}
