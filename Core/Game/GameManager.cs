using System;
using System.Collections.Generic;
using System.Text;
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
                WindowManager.Render();
                Update(); //Not used yet
            }
            //Exits the window, basically
            WindowManager.Finish();
        }
        //To be added
        public static void Update()
        {
            
        }
    }
}
