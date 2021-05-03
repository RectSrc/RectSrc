using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RectSrc.Core.Game;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace RectSrc.Core.IO
{
    public static class GameLoader
    {
        public static void SaveLevel(Level level, string path) 
        {
            Stream s = File.Open(path, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
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
    }
}
