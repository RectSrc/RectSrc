using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Game.Entities;
using RectSrc.Core.Rendering;

namespace RectSrc.Core.Game
{
    public static class GameManager
    {
        public static Level level;
        public static void Run(Level levelToRun)
        {
            //Sets the level
            level = levelToRun;
            WindowManager.Init();
            //Inits every entity in the level
            for (int i = 0; i < level.entities.Count; i++)
            {
                level.entities[i].Init();
            }
            //Makes sure to call the render in each entity
            while (!Raylib_cs.Raylib.WindowShouldClose())
            {
                Update();
                WindowManager.Render();
            }
            //Exits the window, basically
            WindowManager.Finish();
        }
        //Update every entity
        public static void Update()
        {
            for (int i = 0; i < level.entities.Count; i++)
            {
                level.entities[i].Update();
            }
        }
    }
}
