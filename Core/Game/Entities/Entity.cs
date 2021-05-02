using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Math;
using Raylib_cs;
namespace RectSrc.Core.Game.Entities
{

    public abstract class Entity
    {
        public Transform transform = new Transform();

        public virtual void Init()
        {

        }

        public virtual void BeforeRender()
        {

        }

        public virtual void OnRender()
        {
            Raylib.DrawCube(transform.pos.systemized, 5, 5, 5, Color.GREEN);
        }

        public virtual void AfterRender()
        {

        }
    }

    public class Cube : Entity
    {
        public override void OnRender()
        {
            Raylib.DrawCube(transform.pos.systemized, 5, 5, 5, Color.GREEN);
        }
    }

    public class Camera : Entity
    {
        public Camera3D self;

        public Camera()
        {

        }

        public override void Init()
        {
            this.transform = new Transform();
            this.self = new Camera3D(transform.pos.systemized, Vector3.zero.systemized, Vector3.up.systemized, 90, CameraType.CAMERA_PERSPECTIVE);
        }
        public override void BeforeRender()
        {
            Raylib.BeginMode3D(self);
        }

        public override void AfterRender()
        {
            Raylib.EndMode3D();
        }
    }

    public class Transform
    {
        public Vector3 pos;
        public Transform()
        {
            this.pos = Vector3.zero;
        }
        public Transform(Vector3 pos)
        {
            this.pos = pos;
        }
    }
}
