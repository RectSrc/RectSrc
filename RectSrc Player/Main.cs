
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
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
            GameData game = GameLoader.LoadGame(Directory.GetCurrentDirectory() +  "/engine/static/data.rsg");
            GameManager.Run(game.levels[0]);
        }
    }
}
