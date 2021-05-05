using System;
using System.Collections.Generic;
using System.Text;
using RectSrc.Core.Math;
using Raylib_cs;
namespace RectSrc.Core.Game.Entities
{
    [Serializable]
    public abstract class Entity
    {
        //The transform of the entity
        public Transform transform = new Transform();
        //Is it an UI entity?
        public bool UIEntity = false;
        //The reference name of the entity
        public string name = "null";
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
    [Serializable]
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
    [Serializable]
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
    [Serializable]
    public class Cube : Entity
    {
        //A cube... scale does not apply

        public Cube()
        {
            transform = new Transform();
        }
        public Cube(Vector3 pos)
        {
            transform = new Transform(pos);
        }
        public override void OnRender()
        {
            Raylib.DrawCube(transform.position.systemized, 5, 5, 5, Color.GREEN);
        }
    }
    [Serializable]
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
            Raylib.DrawText(text, (int)transform.position.x, (int)transform.position.y, size, Color.BLACK);
        }
    }
    [Serializable]
    public class Camera : Entity
    {
        [Serializable]
        public class SerializableCamera3D
        {
            public float fov;
            public Vector3 target;

            public SerializableCamera3D(Camera3D camera)
            {
                fov = camera.fovy;
                target = Vector3.FromSystem(camera.target);
            }

            public static Camera3D FromSerializedCam(SerializableCamera3D serializableCamera)
            {
                Camera3D retVal = new Camera3D(Vector3.zero.systemized, Vector3.zero.systemized, Vector3.up.systemized, serializableCamera.fov, CameraType.CAMERA_PERSPECTIVE);
                retVal.target = serializableCamera.target.systemized;
                return retVal;
            }
        }
        // A Camera3D intergration from raylib, just handles the basics like the transform
        [NonSerialized]
        Camera3D self;


        SerializableCamera3D _self;

        public float fov
        {
            get { return self.fovy; }
            set { self.fovy = value; _self.fov = fov; }
        }
        public Vector3 target
        {
            get { return Vector3.FromSystem(self.target); }
            set { self.target = value.systemized; _self.target = value; }
        }

        public Camera(SerializableCamera3D serializableCamera)
        {
            self = SerializableCamera3D.FromSerializedCam(serializableCamera);
        }

        public Camera(Vector3 pos)
        {
            transform.position = pos;
        }

        public override void Init()
        {
            this.self = new Camera3D(transform.position.systemized, Vector3.zero.systemized, Vector3.up.systemized, 45.0f, CameraType.CAMERA_PERSPECTIVE);
            if (_self != null)
            {
                this.fov = _self.fov;
                this.target = _self.target;
            }
            else
            {
                _self = new SerializableCamera3D(this.self);
            }
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

        public override void Update()
        {
            self.position = transform.position.systemized;
        }
    }
    [Serializable]
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
