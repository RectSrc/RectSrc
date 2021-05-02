using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Math;
using Raylib_cs;
namespace RectSrc.Core.Game.Entities
{

    public abstract class Entity
    {
        //The transform of the entity
        public Transform transform = new Transform();
        //Is it an UI entity?
        public bool UIEntity = false;
        //Call orders in pseudo code:
        //Init();
        //forever:
        //  BeforeRender();
        //  OnRender();
        //  AfterRender();
        public virtual void Init()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void BeforeRender()
        {

        }

        public virtual void OnRender()
        {
            Raylib.DrawCube(transform.position.systemized, 5, 5, 5, Color.GREEN);
        }

        public virtual void AfterRender()
        {

        }
    }
    
    public abstract class UIentity : Entity
    {
        //Like a standard entity but only gets the UIrender call and that happens last, also, it has the UIentity set to true
        public new bool UIEntity = true;
        public UIentity()
        {
            this.UIEntity = true;
        }
        public virtual void UIRender()
        {
            Raylib.DrawText("UIent!", (int)transform.position.x, (int)transform.position.y, 10, Color.BLACK);
        }
    }

    public class Model : Entity
    {
        //Stores a model and renders it
        Raylib_cs.Model model;

        public Model(Raylib_cs.Model model)
        {
            this.model = model;
        }
        
        public Model(string fileName)
        {
            this.model = Raylib.LoadModel(fileName);
        }
        public override void OnRender()
        {
            Raylib.DrawModelEx(model, transform.position.systemized, Vector3.zero.systemized, 0, transform.scale.systemized, Color.WHITE);
        }
    }

    public class Cube : Entity
    {
        //A cube... scale does not apply
        public override void OnRender()
        {
            Raylib.DrawCube(transform.position.systemized, 5, 5, 5, Color.GREEN);
        }

        public override void Update()
        {
            transform.position.x += Raylib.GetFrameTime();
        }
    }

    public class Text : UIentity
    {
        public string text;
        public int size = 10;

        public Text(string text, int size)
        {
            this.UIEntity = true;
            this.text = text;
            this.size = size;
        }

        public Text(string text)
        {
            this.UIEntity = true;
            this.text = text;
        }

        public override void UIRender()
        {
            Console.WriteLine("UIENTITY!");
            Raylib.DrawText(text, (int)transform.position.x, (int)transform.position.y, size, Color.BLACK);
        }
    }

    public class Camera : Entity
    {
        // A Camera3D intergration from raylib, just handles the basics like the transform
        Camera3D self;
        public float fov
        {
            get { return self.fovy; }
            set { self.fovy = value; }
        }
        public Vector3 target
        {
            get { return Vector3.FromSystem(self.target); }
            set { self.target = value.systemized; }
        }

        public Camera()
        {

        }

        public override void Init()
        {
            this.self = new Camera3D(transform.position.systemized, Vector3.zero.systemized, Vector3.up.systemized, 45.0f, CameraType.CAMERA_PERSPECTIVE);
        }

        public override void BeforeRender()
        {
            Raylib.BeginMode3D(self);
        }

        public override void AfterRender()
        {
            Raylib.EndMode3D();
            Raylib.DrawFPS(10, 10);
        }
    }

    public class Transform
    {
        // A transform: A transformation in a 3D space
        public Vector3 position;
        public Vector3 scale;
        public Transform()
        {
            this.position = Vector3.zero;
        }
        public Transform(Vector3 pos, Vector3 scale)
        {
            this.position = pos;
            this.scale = scale;
        }
        public Transform(Vector3 pos)
        {
            this.position = pos;
            this.scale = Vector3.one;
        }
    }
}
