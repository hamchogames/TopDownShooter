#region Includes
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using TopDownShooterPrompt;
#endregion

namespace TopDownShooter
{
    public class GridLocation
    {
        public bool filled, impassible, unPathable;
        public float fScore, cost, currentDist;

        public GridLocation(float COST, bool FILLED)
        {
            cost = COST;
            filled = FILLED;

            unPathable = false;
            impassible = false;
        }

        public virtual void SetToFilled(bool IMPASSABLE)
        {
            filled = true;
            impassible = IMPASSABLE;
        }

    }
}
