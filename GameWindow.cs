using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.Threading;
using System.Numerics;
using System.IO;
namespace RectSrc.Game.Rendering
{
    public static class GameWindow
    {
        public static Queue<RenderCall> renders;
        public static Dictionary<string, Model> models;
        public static void InitRenderer()
        {
            renders = new Queue<RenderCall>();
            models = new Dictionary<string, Model>();
        }

        public static void LoadMesh(string meshName)
        {
            Console.WriteLine("Loading mesh...");
            Model mesh = Raylib.LoadModel(Directory.GetCurrentDirectory() + "/models/" + meshName + ".obj");
            models.Add(meshName, mesh);
        }

        public static void DrawCall(RenderCall call)
        {
            Console.Write("");
            renders.Enqueue(call);
        }
    }

    public class RenderCall
    {
        public string mesh;
        public System.Numerics.Vector3 pos;
    }
}
