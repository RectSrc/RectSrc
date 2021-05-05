using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RectSrc.Core.Game;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace RectSrc.Core.IO
{
    public static class GameLoader
    {
        public static void SaveLevel(Level level, string path, string gameName) 
        {
            //Console.WriteLine("Creating level filestream to " + path + "...");
            Stream s = File.Open(path, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            //Console.WriteLine("Serializing level and writing it...");
            b.Serialize(s, level);
            s.Close();
        }
        public static Level LoadLevel(string path)
        {
            Level c = new Level();
            Stream s = File.Open(path, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            c = (Level)b.Deserialize(s);
            s.Close();
            return c;
        }

        public static void SaveGame(GameData game)
        {
            //Console.WriteLine("Creating directories...");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/" + game.name);
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/RectSrc/static");
            //Console.WriteLine("Writing the game...");
            //Console.WriteLine("Opening file stream...");
            Stream s = File.Open(Directory.GetCurrentDirectory() + "/RectSrc/static/data.rsg", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            //Console.WriteLine("Writing the levels...");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/" + game.name + "/levels");
            foreach (var item in game.levels)
            {
                SaveLevel(item, Directory.GetCurrentDirectory() + "/" + game.name + "/levels/" + item.name + ".rsl", game.name);
                game.levelPaths.Add(game.name + "/levels/" + item.name);
            }
            b.Serialize(s, game);
            s.Close();
        }
        public static GameData LoadGame(string path)
        {
            GameData c = new GameData();
            Stream s = File.Open(path, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            c = (GameData)b.Deserialize(s);
            s.Close();
            c.levels = new List<Level>();
            foreach (var item in c.levelPaths)
            {
                c.levels.Add(LoadLevel(Directory.GetCurrentDirectory() + "/" + item + ".rsl"));
            }
            return c;
        }
    }
}
