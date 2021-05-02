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
            level = levelToRun;
            WindowManager.Init();
            for (int i = 0; i < level.entities.Count; i++)
            {
                level.entities[i].Init();
            }
            while (!Raylib_cs.Raylib.WindowShouldClose())
            {
                WindowManager.Render();
            }
            WindowManager.Finish();
        }

        public static void Update()
        {
            
        }
    }
}
