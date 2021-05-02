using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Game.Entities;
namespace RectSrc.Core.Game
{

    public class Level
    {
        public List<Entity> entities;
        public Level()
        {
            entities = new List<Entity>();
        }

        public Entity GetEntity(string name)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].name == name)
                    return entities[i];
            }
            return null;
        }
    }
}
