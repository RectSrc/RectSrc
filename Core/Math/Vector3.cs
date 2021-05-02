using System;
using System.Collections.Generic;
using System.Text;

namespace RectSrc.Core.Math
{
    public class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float magnitude
        {
            get
            {
                // Calculate the magnitude(length) of the vector, this is simply done with some trigonometry;
                float XY = Mathf.Sqrt((x * x) + (y * y));
                float XYZ = Mathf.Sqrt((XY * XY) + (z * z));
                return XYZ;
            }
        }
        //Convert the vector into a System.Numerics vector
        public System.Numerics.Vector3 systemized
        {
            get
            {
                return new System.Numerics.Vector3(x, y, z);
            }
            set
            {
                x = value.X;
                y = value.Y;
                z = value.Z;
            }
        }
        //Convert a system.numerics vector >:)
        public static Vector3 FromSystem(System.Numerics.Vector3 vector3)
        {
            return new Vector3(vector3.X, vector3.Y, vector3.Z);
        }
        //Normalize it...
        public Vector3 normalized
        {
            get
            {
                Vector3 n = new Vector3(0, 0, 0);
                if (this.x != 0)
                    n.x = this.x / this.magnitude;
                if (this.y != 0)
                    n.y = this.y / this.magnitude;
                if (this.z != 0)
                    n.z = this.z / this.magnitude;
                return n;
            }
        }

        //Operations, +-*/, the standard ones

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator / (Vector3 a, float b)
        {
            Vector3 n = new Vector3(0, 0, 0);
            if (a.x != 0)
                n.x = a.x / b;
            if (a.y != 0)
                n.y = a.y / b;
            if (a.z != 0)
                n.z = a.z / b;
            return n;
        }
        // * and / but with an int :)
        public static Vector3 operator *(Vector3 a, int b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator /(Vector3 a, int b)
        {
            Vector3 n = new Vector3(0, 0, 0);
            if (a.x != 0)
                n.x = a.x / b;
            if (a.y != 0)
                n.y = a.y / b;
            if (a.z != 0)
                n.z = a.z / b;
            return n;
        }


        //The directions, and some more

        public static readonly Vector3 zero = new Vector3(0, 0, 0);
        public static readonly Vector3 one = new Vector3(0, 0, 0);
        public static readonly Vector3 up = new Vector3(0, 1, 0);
        public static readonly Vector3 down = new Vector3(0, -1, 0);
        public static readonly Vector3 left = new Vector3(-1, 0, 0);
        public static readonly Vector3 right = new Vector3(1, 0, 0);
        public static readonly Vector3 forward = new Vector3(0, 0, 1);
        public static readonly Vector3 backward = new Vector3(0, 0, -1);


}
}
