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

        PassObject ApplyOptions;

        public OptionsMenu(PassObject APPLYOPTION) 
        {
            ApplyOptions = APPLYOPTION;

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

            XDocument xml = Globals.save.GetFile("XML\\options.xml");

            LoadData(xml);
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
            SaveOptions();

            Globals.gameState = 0;
        }

        public virtual FormOption GetOptionValue(string NAME)
        {
            for (int i = 0; i<arrowSelectors.Count; i++)
            {
                if (arrowSelectors[i].title == NAME)
                {
                    return arrowSelectors[i].GetCurrentOption();
                }
            }

            return null;
        }

        public virtual void LoadData(XDocument DATA)
        {
            if(DATA != null)
            {
                List<string> allOptions = new List<string>();

                for (int i = 0; i < arrowSelectors.Count; i++)
                {
                    allOptions.Add(arrowSelectors[i].title);
                }

                for (int i = 0; i < allOptions.Count;i++) {
                    List<XElement> optionList = (from t in DATA.Element("Root").Element("Options").Descendants("Option")
                                                 where t.Element("name").Value == allOptions[i]
                                                 select t).ToList<XElement>();
                    if (optionList.Count > 0)
                    {
                        for (int j = 0; j < arrowSelectors.Count; j++)
                        {
                            if (arrowSelectors[j].title == allOptions[i])
                            {
                                arrowSelectors[j].selected = Convert.ToInt32(optionList[0].Element("selected").Value, Globals.culture);
                            }
                        }
                    }
                }
            }
        }

        public virtual void SaveOptions()
        {
            XDocument xml = new XDocument(new XElement("Root", 
                                                 new XElement("Options", "")));

            for (int i = 0; i< arrowSelectors.Count; i++)
            {
                xml.Element("Root").Element("Options").Add(arrowSelectors[i].ReturnXML());
            }

            Globals.save.HandleSaveFormates(xml, "options.xml");

            ApplyOptions(null);
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
