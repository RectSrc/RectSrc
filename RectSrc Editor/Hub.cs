using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
namespace RectSrc.Editor.Old
{
    [Obsolete("Replaced by the W.I.P Electron.Net project instead", true)]
    public static class Hub
    {
        static bool hasTriedClosing = false;
        static float aspectRatioFromHeight = 16f / 9f;
        static float aspectRatioFromWidth = 9f / 16f;
        [Obsolete("Replaced by the W.I.P Electron.Net project instead", true)]
        public static void Run(string[] args)
        {
            Raylib.InitWindow(1600, 900, "RectSrc Hub");
            Raylib.SetTargetFPS(60);
            Raylib.SetWindowState(ConfigFlag.FLAG_WINDOW_RESIZABLE);
            Camera2D camera = new Camera2D();
            camera.target = new Vector2(0, 0);
            camera.rotation = 0.0f;
            camera.zoom = 1.0f;
            while (!Raylib.WindowShouldClose())
            {

                if (Raylib.IsWindowResized())
                {
                    if (Raylib.GetScreenWidth() > Raylib.GetScreenHeight())
                        Raylib.SetWindowSize(Raylib.GetScreenWidth(), (int)(Raylib.GetScreenWidth() * aspectRatioFromWidth));
                    else
                        Raylib.SetWindowSize((int)(Raylib.GetScreenHeight() * aspectRatioFromHeight), Raylib.GetScreenHeight());
                    camera.zoom = MathF.Min(Raylib.GetScreenWidth() / 1600f, Raylib.GetScreenHeight() / 900f);
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);
                Raylib.BeginMode2D(camera);
                //Drawing here




                //End of drawing
                Raylib.DrawFPS(5, 5);


                Raylib.EndMode2D();
                Raylib.EndDrawing();
            }
            CloseWindow();

        }

        public static void CloseWindow()
        {
            if (!hasTriedClosing)
            {
                Raylib.CloseWindow();
                hasTriedClosing = true;
            }
        }
    }
}
