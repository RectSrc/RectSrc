//RectSrc/Core/Ext/ReCTInterface.cs, the only file wich will be breaking the rules used by others, it will also be kinda annoying, but needed, it interfaces with rect ig :)
using System;
using RectSrc;
using RectSrc.Core;

namespace RectSrc
{
    public static class RectSrc
    {
        public static Core.Game.Entities.Entity GetEntity(string name) => Core.Game.GameManager.level.GetEntity(name);
    }
}
