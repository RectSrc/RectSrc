using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RectSrc.Core.Game;
namespace RectSrc.Core.IO
{
    public static class GameLoader
    {
        public static Level LoadLevel(string path)
        {
            return JsonConvert.DeserializeObject<Level>(File.ReadAllText(path));
        }

        public static void SaveLevel(Level level, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(level));
        }
    }
}
