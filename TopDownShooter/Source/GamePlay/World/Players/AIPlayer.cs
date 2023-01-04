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
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
#endregion

namespace TopDownShooter
{
    public class AIPlayer : Player
    {

        public AIPlayer(int ID, XElement DATA) : base(ID, DATA)
        {

            /* spawnPoints.Add(new Portal(new Vector2(50, 50), id));

             spawnPoints.Add(new Portal(new Vector2(Globals.screenWidth / 2, 50), id));
             spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

             spawnPoints.Add(new Portal(new Vector2(Globals.screenWidth - 50, 50), id));
             spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);*/

            Debug.WriteLine("AI Player");
        }
        public override void Update(Player ENEMY, Vector2 OFFSET, SquareGrid GRID)
        {
            base.Update(ENEMY, OFFSET, GRID);
        }

        public override void ChangeScore(int SCORE)
        {
            GameGlobals.score += SCORE;
        }
  


    }
}
