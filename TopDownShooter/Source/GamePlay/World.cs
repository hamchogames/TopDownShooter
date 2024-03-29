﻿#region Includes
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
    public class World
    {

        public int levelId;

        public Vector2 offset;

        public CharacterMenu characterMenu;

        public UI ui;

        public User user;
        public AIPlayer aIPlayer;

        public SquareGrid grid;

        public TileBkg2d bkg;

        public LevelDrawManager levelDrawManager;

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public List<Effect2d> effects = new List<Effect2d>();
        public List<AttackableObject> allObjects = new List<AttackableObject>();
        public List<SceneItem> sceneItems = new List<SceneItem>();
      

        PassObject ResetWorld, ChangeGameState;
        


        public World(PassObject RESETWORLD, int LEVELID, PassObject CHANGEGAMESTATE) 
        {
            levelId = LEVELID;

            ResetWorld = RESETWORLD;
            ChangeGameState = CHANGEGAMESTATE;

            levelDrawManager = new LevelDrawManager();


            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassEffect = AddEffect;
            GameGlobals.PassMob = AddMob;
            GameGlobals.PassBuilding = AddBuilding;
            GameGlobals.CheckScroll = CheckScroll;
            GameGlobals.PassSpawnPoint= AddSpawnPoint;
            GameGlobals.PassGold = AddGold;


            GameGlobals.paused = false;


            offset = new Vector2(0, 0);

            LoadData(levelId);

            characterMenu = new CharacterMenu(user.hero);

            ui = new UI(ResetWorld, user.hero);

            bkg = new TileBkg2d("2d\\UI\\Backgrounds\\StandardDirt", new Vector2(-100, -100), new Vector2(120, 100), new Vector2(grid.totalPhysicalDims.X + 100, grid.totalPhysicalDims.Y + 100));
        }
        public virtual void Update()
        {
            ui.Update(this);

            if (!DontUpdate())
            {
                levelDrawManager.Update();


                allObjects.Clear();
                allObjects.AddRange(user.GetAllObjects());
                allObjects.AddRange(aIPlayer.GetAllObjects());

                user.Update(aIPlayer, offset, grid, levelDrawManager);
                aIPlayer.Update(user, offset, grid, levelDrawManager);
                

                

                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, allObjects);

                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < effects.Count; i++)
                {
                    effects[i].Update(offset);

                    if (effects[i].done)
                    {
                        effects.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < sceneItems.Count; i++)
                {
                    sceneItems[i].Update(offset);

                    sceneItems[i].UpdateDraw(offset, levelDrawManager);
                }

            }

            else
            {
                if (Globals.keyboard.GetPress("Enter") && (user.hero.dead || user.buildings.Count <= 0))
                {
                    ResetWorld(null);
                }
            }

            characterMenu.Update();

            if (grid != null)
            {
                grid.Update(offset);
            }


            if (Globals.keyboard.GetSinglePress("Back"))
            {
                ResetWorld(null);
                ChangeGameState(0);
            }

            
            if (Globals.keyboard.GetSinglePress("Space"))
            {
                GameGlobals.paused = !GameGlobals.paused;
            }

            if (Globals.keyboard.GetSinglePress("G"))
            {
                grid.showGrid = !grid.showGrid;
            }

            if (Globals.keyboard.GetSinglePress("C"))
            {
                characterMenu.Active = !characterMenu.Active;
            }




        }

        public virtual void AddBuilding(object INFO)
        {
            Building tempBuilding = (Building)INFO;

            if (user.id == tempBuilding.ownerId)
            {
                user.AddBuilding(tempBuilding);
            }
            else if (aIPlayer.id == tempBuilding.ownerId)
            {
                aIPlayer.AddBuilding(tempBuilding);
            }
            //aIPlayer.AddBuilding((Mob)INFO);
        }

        public virtual void AddEffect(object INFO)
        {
            effects.Add((Effect2d)INFO);
        }
        
        public virtual void AddGold(object INFO)
        {
            PlayerValuePacket packet = (PlayerValuePacket)INFO;

            if (user.id == packet.playerId)
            {
                user.gold += (int)packet.value;
            }
            else if (aIPlayer.id == packet.playerId)
            {
                aIPlayer.gold += (int)packet.value;
            }

        }

        public virtual void AddMob(object INFO)
        {
            Unit tempUnit = (Unit)INFO;

            if(user.id == tempUnit.ownerId)
            {
                user.AddUnit(tempUnit);
            }
            else if(aIPlayer.id == tempUnit.ownerId)
            {
                aIPlayer.AddUnit(tempUnit);
            }
          //  aIPlayer.AddUnit((Mob)INFO);
        }
        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }



        public virtual void AddSpawnPoint(object INFO)
        {
            SpawnPoint tempSpawnPoint = (SpawnPoint)INFO;

            if (user.id == tempSpawnPoint.ownerId)
            {
                user.AddSpawnPoint(tempSpawnPoint);
            }
            else if (aIPlayer.id == tempSpawnPoint.ownerId)
            {
                aIPlayer.AddSpawnPoint(tempSpawnPoint);
            }
          
        }

        public virtual void CheckScroll(Object INFO)
        {
            Vector2 tempPos = (Vector2)INFO;

            float maxMovement = user.hero.speed * 4.5f; //change the camera speed here

            float diff = 0;

            if (tempPos.X < -offset.X + (Globals.screenWidth * .4f))
            {
                diff = -offset.X + (Globals.screenWidth * .4f) - tempPos.X;

                offset = new Vector2(offset.X + Math.Min(maxMovement, diff), offset.Y);
            }
            if (tempPos.X > -offset.X + (Globals.screenWidth * .6f))
            {
                diff = tempPos.X - (-offset.X + (Globals.screenWidth * .6f));

                offset = new Vector2(offset.X - Math.Min(maxMovement, diff), offset.Y);
            }

            if (tempPos.Y < -offset.Y + (Globals.screenHeight * .4f))
            {
                diff = -offset.Y + (Globals.screenHeight * .4f) - tempPos.Y;

                offset = new Vector2(offset.X, offset.Y + Math.Min(maxMovement, diff));
            }
            if (tempPos.Y > -offset.Y + (Globals.screenHeight * .6f))
            {
                diff = tempPos.Y - (-offset.Y + (Globals.screenHeight * .6f));

                offset = new Vector2(offset.X, offset.Y - Math.Min(maxMovement, diff));
            }

            /*if (tempPos.X < -offset.X + (Globals.screenWidth * .4f))
            {
                offset = new Vector2(offset.X + user.hero.speed * 2, offset.Y);
            }
            if (tempPos.X > -offset.X + (Globals.screenWidth * .6f))
            {
                offset = new Vector2(offset.X - user.hero.speed * 2, offset.Y);
            }

            if (tempPos.Y < -offset.Y + (Globals.screenHeight * .4f))
            {
                offset = new Vector2(offset.X, offset.Y + user.hero.speed * 2);
            }
            if (tempPos.Y > -offset.Y + (Globals.screenHeight * .6f))
            {
                offset = new Vector2(offset.X, offset.Y - user.hero.speed * 2);
            }*/

        }

        public virtual bool DontUpdate()
        {
            if(user.hero.dead || user.buildings.Count == 0 || GameGlobals.paused || ui.skillMenu.active || characterMenu.Active)
            {
                return true;
            }
            return false;
        }

        public virtual void LoadData(int LEVEL)
        {
            XDocument xml = XDocument.Load("XML\\Levels\\Level" + LEVEL + ".xml");

            XElement tempElement = null;
            if (xml.Element("Root").Element("User") != null) 
            {
                tempElement = xml.Element("Root").Element("User");
            }

            user = new User(1, tempElement);

            tempElement = null;
            if (xml.Element("Root").Element("AIPlayer") != null)
            {
                tempElement = xml.Element("Root").Element("AIPlayer");
            }

            grid = new SquareGrid(new Vector2(25, 25), new Vector2(-100, -100), new Vector2(Globals.screenWidth + 200, Globals.screenHeight + 200), xml.Element("Root").Element("GridItems"));



            aIPlayer = new AIPlayer(2, tempElement);

            List<XElement> SceneItemList = (from t in xml.Element("Root").Element("Scene").Descendants("SceneItem")
                                           select t).ToList<XElement>();


            Type sType = null;
            for (int i = 0; i < SceneItemList.Count; i++)
            {
                sType = Type.GetType("TopDownShooter." + SceneItemList[i].Element("type").Value, true);
                sceneItems.Add((SceneItem)(Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(SceneItemList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(SceneItemList[i].Element("Pos").Element("y").Value, Globals.culture)), new Vector2((float)Convert.ToDouble(SceneItemList[i].Element("scale").Value, Globals.culture)))));
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            bkg.Draw(offset);
            grid.DrawGrid(offset);

            user.Draw(offset);
            aIPlayer.Draw(offset);

           /* for (int i = 0; i < sceneItems.Count; i++)
            {
                sceneItems[i].Draw(offset);

            }*/
           if(levelDrawManager != null)
            {
                levelDrawManager.Draw();
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);

            }

            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].Draw(offset);

            }

            ui.Draw(this);

            characterMenu.Draw();
        }
        
    }
}
