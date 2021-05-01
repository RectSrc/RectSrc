using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using Mono.Cecil;
using System.IO;
using RectSrc.Core.Game;
namespace RectSrc.Bin
{
    public static class MainProgram
    {
        public static void Main(string[] args)
        {
            GameManager.Run();
        }
    }
}
