//RectSrc/Core/Ext/ReCTInterface.cs, the only file wich will be breaking the rules used by others, it will also be kinda annoying, but needed, it interfaces with rect ig :)
using System;
using RectSrc;
using RectSrc.Core;
//Smol change

namespace RectSrc
{
    public static class RectSrc
    {
        public static Core.Game.Entities.Entity GetEntity(string name) => Core.Game.GameManager.level.GetEntity(name);
        public static void DrawCube(Vector3 pos, Vector3 size, Color color) => Raylib_cs.Raylib.DrawCubeV((System.Numerics.Vector3)pos.systemized,(System.Numerics.Vector3)size.systemized, (Raylib_cs.Color)color.ToRaylib());




        //Class definitions
        public class Vector3
        {
            private Core.Math.Vector3 vector3;
            public float x => vector3.x;
            public float y => vector3.y;
            public float z => vector3.z;
            public float magnitude() => vector3.magnitude;
            public Vector3 normalized => FromInternal(vector3.normalized);
            public Vector3(float x, float y, float z)
            {
                vector3 = new Core.Math.Vector3(x, y, z);
            }
            private static Vector3 FromInternal(Core.Math.Vector3 vector3)
            {
                return new Vector3(vector3.x, vector3.y, vector3.z);
            }

            public object systemized => vector3.systemized;
        }

        public class Color
        {
            private Raylib_cs.Color color;
            public byte r => color.r;
            public byte g => color.g;
            public byte b => color.b;
            public byte a => color.a;

            public Color(int r, int g, int b, int a)
            {
                color = new Raylib_cs.Color(r, g, b, a);
            }

            public object ToRaylib()
            {
                return (object)color;
            }
        }
    }
}
