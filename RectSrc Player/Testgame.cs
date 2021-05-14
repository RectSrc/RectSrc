using System;
using System.Collections.Generic;
using System.Text;
using RectSrc;
using RectSrc.Bin;
using RectSrc.Core;
using RectSrc.Core.Game;
using RectSrc.Core.Game.Entities;
using RectSrc.Core.Rendering;
using RectSrc.Core.IO;
using RectSrc.Core.Math;
using Raylib_cs;
using System.IO;
namespace ExtTest
{
    public static class Testgame
    {

        public static void Run()
        {

            Level level = new Level();
            level.name = "test";
            level.entities.Add(new CubeFollowCamera(Vector3.one * 10));
            level.entities.Add(new MovingCube(Vector3.zero));
            GameData game = new GameData("Cubeisthebest");
            game.levels.Add(level);
            GameLoader.SaveGame(game);
            /*GameData*/
            game = GameLoader.LoadGame(Directory.GetCurrentDirectory() + "/engine/static/data.rsg");
            GameManager.Run(game.levels[0]);
        }
    }
    [Serializable]
    public class MovingCube : Entity
    {
        public override void OnRender()
        {
            Raylib.DrawCube(transform.position.systemized, 1, 1, 1, new Color(Mathf.Clamp((int)transform.position.x, 0, 255), Mathf.Clamp((int)transform.position.y, 0, 255), Mathf.Clamp((int)transform.position.z, 0, 255), 255));
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
                transform.position.x++;
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                transform.position.x--;
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
                transform.position.z++;
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
                transform.position.z--;
        }

        public MovingCube(Vector3 pos)
        {
            transform.position = pos;
            name = "Cube";
        }


    }
    [Serializable]
    public class CubeFollowCamera : Entity
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

        public CubeFollowCamera(SerializableCamera3D serializableCamera)
        {
            self = SerializableCamera3D.FromSerializedCam(serializableCamera);
        }

        public CubeFollowCamera(Vector3 pos)
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
            Raylib.DrawText(GameManager.level.GetEntity("Cube").transform.position.ToString(), 5, 30, 10, Color.BLACK);
        }

        public override void Update()
        {
            self.position = transform.position.systemized;
            target = GameManager.level.GetEntity("Cube").transform.position;
            transform.position = GameManager.level.GetEntity("Cube").transform.position + Vector3.one * 10;
        }
    }
}
