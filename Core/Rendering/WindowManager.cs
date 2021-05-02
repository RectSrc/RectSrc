using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using RectSrc.Core.Game;
using RectSrc.Core.Game.Entities;

namespace RectSrc.Core.Rendering
{
    public static class WindowManager
    {
        public static void Init()
        {
            //Sets the window name, size, fps and enables VSYNC
            Raylib.InitWindow(500, 500, "ReCTSrc Game");
            Raylib.SetTargetFPS(60);
            Raylib.SetWindowState(ConfigFlag.FLAG_VSYNC_HINT);
        }

        public static void Render()
        {
            //Begins drawing, clears, calls the scripts *Render functions and stops drawing
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            for (int i = 0; i < GameManager.level.entities.Count; i++)
            {
                if (!GameManager.level.entities[i].UIEntity)
                    GameManager.level.entities[i].BeforeRender();
            }
            for (int i = 0; i < GameManager.level.entities.Count; i++)
            {
                if (!GameManager.level.entities[i].UIEntity)
                    GameManager.level.entities[i].OnRender();
            }
            for (int i = 0; i < GameManager.level.entities.Count; i++)
            {
                //Only render non-ui entities first
                if (!GameManager.level.entities[i].UIEntity)
                    GameManager.level.entities[i].AfterRender();
            }
            for (int i = 0; i < GameManager.level.entities.Count; i++)
            {
                //Only render ui entities last
                if (GameManager.level.entities[i].UIEntity)
                    ((UIentity)GameManager.level.entities[i]).UIRender();
            }
            Raylib.EndDrawing();
        }

        public static void Finish()
        {
            //Closes the window 
            Raylib.CloseWindow();
        }
    }
}
