using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Rendering;

namespace RectSrc.Core.Game
{
    public static class GameManager
    {
        public static void Run()
        {
            WindowManager.Init();
            while (!Raylib_cs.Raylib.WindowShouldClose())
            {
                WindowManager.Render();
            }
            WindowManager.Finish();
        }
    }
}
