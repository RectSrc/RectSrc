using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace RectSrc.Editor
{
    public class OperatorExtentions
    {
    }
    public static class Editor
    {
        static bool devMode = false;
        public static void Run(string[] args)
        {
            //Init functions
            Raylib.InitWindow(500, 500, "RectSrc Editor"); //Init window
            Raylib.SetTargetFPS(60); //Target 60 FPS
            //Set window to take up entire screen
            Raylib.SetWindowState(ConfigFlag.FLAG_WINDOW_UNDECORATED); //Hide top bar
            Raylib.SetWindowState((ConfigFlag)((int)ConfigFlag.FLAG_WINDOW_MAXIMIZED | (int)ConfigFlag.FLAG_WINDOW_RESIZABLE)); //Maximize the window
            Raylib.SetWindowMinSize(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()); //Set the maximized size to min size
            Raylib.MaximizeWindow(); //Maximize again


            while (!Raylib.WindowShouldClose())
            {
                Update();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Draw();
                Raylib.EndDrawing();
            }
        }
        public static void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5))
                devMode = !devMode;
        }
        public static void Draw()
        {
            new Button(Vector2.One * 10, Vector2.One * 20, ButtonColorScheme.standard, "hi!").Draw();

            //Dev info, draw last!
            if (devMode)
            {
                Raylib.DrawText(Raylib.GetFPS().ToString() + " FPS", 1, 1, 10, Color.BLACK);
                Raylib.DrawText("Mouse, X: " + Raylib.GetMousePosition().X + " Y: " + Raylib.GetMousePosition().Y, 1, 15, 10, Color.BLACK);
                Raylib.DrawText("Verison v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), 1, 29, 10, Color.BLACK);
            }
        }
    }

    public class Button
    {
        public Vector2 pos;
        public Vector2 size;
        public ButtonColorScheme colorScheme;
        public string label = "";
        public void Draw()
        {
            Vector2 mousePos = Raylib.GetMousePosition();
            if (mousePos.X > pos.X && mousePos.Y > pos.Y && mousePos.X < pos.X + size.X && mousePos.Y < pos.Y + size.Y)
            {
                if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    if (colorScheme.castShadow)
                        Raylib.DrawRectangleV(pos + Vector2.One, size, colorScheme.pressedShadow);
                    Raylib.DrawRectangleV(pos, size, colorScheme.pressedColor);
                }
                else
                {
                    if (colorScheme.castShadow)
                        Raylib.DrawRectangleV(pos + Vector2.One, size, colorScheme.shadow);
                    Raylib.DrawRectangleV(pos, size, colorScheme.hoverColor);
                }
            }
            else
            {
                if (colorScheme.castShadow)
                    Raylib.DrawRectangleV(pos + Vector2.One, size, colorScheme.shadow);
                Raylib.DrawRectangleV(pos, size, colorScheme.mainColor);
            }
            Raylib.DrawText(label, (int)pos.X, (int)pos.Y, 10, colorScheme.textColor);
        }

        public Button(Vector2 pos, Vector2 size, ButtonColorScheme colorScheme)
        {
            this.pos = pos;
            this.size = size;
            this.colorScheme = colorScheme;
        }

        public Button(Vector2 pos, Vector2 size, ButtonColorScheme colorScheme, string label) : this(pos, size, colorScheme)
        {
            this.label = label;
        }
    }

    public class ButtonColorScheme
    {
        public Color mainColor;
        public Color shadow;
        public Color hoverColor;
        public Color pressedColor;
        public Color pressedShadow;
        public Color textColor;
        public bool castShadow;

        public ButtonColorScheme(Color mainColor, Color shadow, Color hoverColor, Color pressedColor, Color pressedShadow, Color textColor, bool castShadow)
        {
            this.mainColor = mainColor;
            this.shadow = shadow;
            this.hoverColor = hoverColor;
            this.pressedColor = pressedColor;
            this.pressedShadow = pressedShadow;
            this.castShadow = castShadow;
            this.textColor = textColor;
        }

        public ButtonColorScheme(Color mainColor, Color hoverColor, Color pressedColor, Color textColor)
        {
            this.mainColor = mainColor;
            this.hoverColor = hoverColor;
            this.pressedColor = pressedColor;
            this.textColor = textColor;
        }

        public static readonly ButtonColorScheme standard = new ButtonColorScheme(Color.LIGHTGRAY, Color.GRAY, Color.GRAY, Color.BLACK, Color.GRAY, Color.BLACK, true);
    }
}
