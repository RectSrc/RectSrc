using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using Mono.Cecil;
using System.IO;
using RectSrc.Core.Game;
using RectSrc.Core.Game.Entities;
namespace RectSrc.Bin
{
    public static class MainProgram
    {
        public static void Main(string[] args)
        {
            Level level = new Level();
            Camera cam = new Camera();
            Text text = new Text("Hi!", 20);
            Console.WriteLine(text.UIEntity);
            cam.transform.position = Core.Math.Vector3.one * 10;
            level.entities.Add(cam);
            level.entities.Add(new Cube());
            level.entities.Add(text);
            GameManager.Run(level);
        }
    }
}
