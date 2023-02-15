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
    public class Menu2d
    {
        protected bool active;

        public Vector2 pos, dims, topLeft;

        public Animated2d bkg;
        
        public Button2d closeBtn;

        public SpriteFont font;

        public PassObject CloseAction;

        public Menu2d(Vector2 POS, Vector2 DIMS, PassObject CLOSEACTION)
        {
            pos = POS;
            dims = DIMS;
            CloseAction = CLOSEACTION;

            bkg = new Animated2d("2d\\Misc\\solid", new Vector2(0, 0), new Vector2(dims.X, dims.Y), new Vector2(1, 1), Color.White);

            closeBtn = new Button2d("2d\\Misc\\XButton", new Vector2(bkg.dims.X, -bkg.dims.Y/2), new Vector2(30, 30), "", "", Close, null);

            font = Globals.content.Load<SpriteFont>("fonts\\Arial16");
        }

        #region

        public virtual bool Active 
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        
        }

        #endregion

        public virtual void Update()
        {   
            if (Active)
            {
                topLeft = pos - dims / 2;

                closeBtn.Update(pos);
            }

        }
        public virtual void Close(object INFO)
        {
            Active = false;
        }

        public virtual void Draw()
        {
            if (Active)
            {
                bkg.Draw(pos);

                closeBtn.Draw(pos);
            }
        }
    }
}
