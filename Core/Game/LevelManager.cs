using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Game.Entities;
namespace RectSrc.Core.Game
{
    public static class LevelManager
    {
        public static Level currentLevel;
    }

    public class Level
    {
        public List<Entity> entities;
        public Level()
        {
            entities = new List<Entity>();
        }
    }
}
