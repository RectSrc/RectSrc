using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace RectSrc.Core.Math
{
    public static class Mathf
    {
        public static float Sin(float x)
        {
            return MathF.Sin(x);
        }
        public static float Cos(float x)
        {
            return MathF.Cos(x);
        }
        public static float Rad(float deg)
        {
            return deg * Mathf.DegToRad;
        }

        public static float Pow(float x, float y)
        {
            return MathF.Pow(x, y);
        }

        public static float Sqr(float num)
        {
            return num * num;
        }

        public static float Sqrt(float num)
        {
            return MathF.Sqrt(num);
        }
        public static readonly float Pi = MathF.PI;
        public static readonly float DegToRad = Mathf.Pi / 180f;
    }
}
