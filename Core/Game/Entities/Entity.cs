using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Math;
namespace RectSrc.Core.Game.Entities
{

    public abstract class Entity
    {
        public Transform transform;
    }

    public class Transform
    {
        public Vector3 pos;
    }
}
