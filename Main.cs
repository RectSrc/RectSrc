using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using Mono.Cecil;
using System.IO;
using RectSrc.Core.Game;
using RectSrc.Core.Game.Entities;
using RectSrc.Core.IO;
namespace RectSrc.Bin
{
    public static class MainProgram
    {
        public static void Main(string[] args)
        {
            Level level = new Level();
            GameManager.Run(level);
        }
    }
}
