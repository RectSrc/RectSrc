using System;
using System.Collections.Generic;
using System.Text;
using RectSrc;
using RectSrc.Core;
using System.Reflection;
using RectSrc.Game.Rendering;
using Raylib_cs;
namespace RectSrc.Game
{
    public static class GameManager
    {

        public static void UpdateAll()
        {
            for (int i = 0; i < MainProgram.classes.Count; i++)
            {
                if (MainProgram.classes[i].classType == ClassType.Script)
                {
                    foreach (var function in MainProgram.classes[i].type.GetMethods(BindingFlags.Static | BindingFlags.Public))
                    {
                        if(function.Name == "Update")
                        {
                            MainProgram.classes[i].type.GetMethod("Update").Invoke(null, null);
                        }
                    }
                }
            }
        }

        public static void StartAll()
        {
            for (int i = 0; i < MainProgram.classes.Count; i++)
            {
                if (MainProgram.classes[i].classType == ClassType.Script)
                {
                    foreach (var function in MainProgram.classes[i].type.GetMethods(BindingFlags.Static | BindingFlags.Public))
                    {
                        if (function.Name == "Start")
                        {
                            MainProgram.classes[i].type.GetMethod("Start").Invoke(null, null);
                        }
                    }
                }
            }
        }

        public static void GameLoop()
        {
            GameWindow.InitRenderer();
            StartAll();
            Raylib.InitWindow(500, 500, "RectSrc Window");
            Raylib.SetTargetFPS(60);
            Camera3D camera = new Camera3D(new System.Numerics.Vector3(1, 1, 1), new System.Numerics.Vector3(0, 0, 0), new System.Numerics.Vector3(0, 1.6f, 0), 90, CameraType.CAMERA_PERSPECTIVE);
            RenderCall renderCall = new RenderCall();
            renderCall.mesh = "cube";
            renderCall.pos = new System.Numerics.Vector3(0, 0, 0);
            GameWindow.DrawCall(renderCall);
            while (!Raylib.WindowShouldClose())
            {
                UpdateAll();
                /*
                GameWindow.DrawCall(renderCall);
                */
                GameWindow.DrawCall(renderCall);
                //Drawing
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Raylib.BeginMode3D(camera);
                Raylib.UpdateCamera(ref camera);
                while (GameWindow.renders.Count > 0)
                {
                    RenderCall draw = GameWindow.renders.Dequeue();
                    if (!GameWindow.models.ContainsKey(draw.mesh))
                        GameWindow.LoadMesh(draw.mesh);
                    Raylib.DrawModel(GameWindow.models[draw.mesh], draw.pos, 1, Color.BLACK);
                }
                //Console.WriteLine("Finished rendering...");
                Raylib.EndMode3D();
                Raylib.DrawFPS(5, 5);
                Raylib.EndDrawing();
                Console.Write("");
            }
            Raylib.CloseWindow();
        }

    }
}
