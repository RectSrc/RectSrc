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
            
            /*Level level = new Level();
            level.name = "test";
            level.entities.Add(new Camera(Core.Math.Vector3.one * 10));
            level.entities.Add(new Cube(Core.Math.Vector3.zero));
            GameData game = new GameData("Game");
            game.levels.Add(level);
            GameLoader.SaveGame(game);*/
            GameData game = GameLoader.LoadGame(Directory.GetCurrentDirectory() + "/RectSrc/static/data.rsg");
            GameManager.Run(game.levels[0]);
        }
    }
}
