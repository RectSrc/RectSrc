using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
namespace RectSrc.Core.Rendering
{
    public static class WindowManager
    {
        public static void Init()
        {
            Raylib.InitWindow(500, 500, "ReCTSrc Game");
            Raylib.SetTargetFPS(60);
            Raylib.SetWindowState(ConfigFlag.FLAG_VSYNC_HINT);
        }

        public static void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawFPS(5, 5);
            Raylib.EndDrawing();
        }

        public static void Finish()
        {
            Raylib.WindowShouldClose();
        }
    }
}
