using System;
using System.Numerics;
using Raylib_cs;

namespace RectSrc.ProjectCreator
{
    class Program
    {
        static Font font;
        static void Main(string[] args)
        {
            Raylib.InitWindow(350, 476, "ReCTSrc Project Creator");
            Raylib.SetWindowState(ConfigFlag.FLAG_WINDOW_UNDECORATED);
            Raylib.SetWindowIcon(Raylib.LoadImage(System.IO.Directory.GetCurrentDirectory() + "/Resources/Images/Icon.png"));
            Raylib.SetTargetFPS(60);
            font = Raylib.LoadFont(System.IO.Directory.GetCurrentDirectory() + "/Resources/Fonts/Bitter-Regular.ttf");
            font = Raylib.GetFontDefault();
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(ColorPallete.Border);
                Vector2 mousePos = Raylib.GetMousePosition();
                if (mousePos.X > 306 && mousePos.X < 306 + 17 && mousePos.Y > 9 && mousePos.Y < 9 + 17)
                {
                    DrawButtonHighlight(new Vector2(306, 9), new Vector2(17, 17));
                    if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                        Raylib.MinimizeWindow();
                }
                else
                {
                    DrawButton(new Vector2(306, 9), new Vector2(17, 17));
                }
                DrawText("_", 306 + 3, 5, 20, Color.WHITE);
                DrawButton(new Vector2(326, 9), new Vector2(17, 17));
                if (mousePos.X > 326 && mousePos.X < 326 + 17 && mousePos.Y > 9 && mousePos.Y < 9 + 17)
                {
                    DrawButtonHighlight(new Vector2(326, 9), new Vector2(17, 17));
                    if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        Raylib.CloseWindow();
                        return;
                    }
                }
                else
                {
                    DrawButton(new Vector2(326, 9), new Vector2(17, 17));
                }
                DrawText("x", 326 + 4, 7, 20, Color.WHITE);
                //DrawField(new Vector2(10, 30), new Vector2(330, 430));
                DrawText("RectSrc project creator", 10, 15, 10, Color.WHITE);
                Raylib.DrawLine(5, 35, 345, 35, ColorPallete.BackGround);
                DrawText("Location: ", 5, 50, 20, Color.WHITE);
                DrawField(new Vector2(Raylib.MeasureText("Location: ", 20) + 10, 50), new Vector2(220, Raylib.MeasureText("#", 20) * 1.5f));
                DrawText("Game: ", 5, 80, 20, Color.WHITE);
                DrawField(new Vector2(Raylib.MeasureText("Location: ", 20) + 10, 80), new Vector2(220, Raylib.MeasureText("#", 20) * 1.5f));
                if (mousePos.X > 120 && mousePos.X < 120 + 100 && mousePos.Y > 400 && mousePos.Y < 400 + 20)
                {
                    DrawButtonHighlight(new Vector2(120, 400), new Vector2(100, 20));
                    if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        CreateGame();
                    }
                }
                else
                {
                    DrawButton(new Vector2(120, 400), new Vector2(100, 20));
                }
                DrawText("Create!", 132, 401, 20, Color.WHITE);

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        static void CreateGame()
        {
            Raylib.DrawFPS(0, 0);
        }
        static void DrawText(string text, int x, int y, int size, Color color)
        {
            Raylib.DrawTextEx(font, text, new Vector2(x, y), size, size / 10f, color);
        }
        static void DrawButton(Vector2 pos, Vector2 size)
        {
            Raylib.DrawRectangleV(pos - Vector2.One, size + Vector2.One * 2, ColorPallete.ButtonDark);
            Raylib.DrawRectangleV(pos - Vector2.One, size + Vector2.One, ColorPallete.ButtonLight);
            Raylib.DrawRectangleV(pos, size, ColorPallete.Border);
        }
        static void DrawButtonHighlight(Vector2 pos, Vector2 size)
        {
            Raylib.DrawRectangleV(pos - Vector2.One, size + Vector2.One * 2, ColorPallete.ButtonDark);
            Raylib.DrawRectangleV(pos - Vector2.One, size + Vector2.One, ColorPallete.ButtonLight);
            Raylib.DrawRectangleV(pos, size, ColorPallete.BackGround);
        }
        static void DrawField(Vector2 pos, Vector2 size)
        {
            Raylib.DrawRectangleV(pos - Vector2.One, size + Vector2.One * 2, ColorPallete.ButtonLight);
            Raylib.DrawRectangleV(pos - Vector2.One, size + Vector2.One, ColorPallete.ButtonDark);
            Raylib.DrawRectangleV(pos, size, ColorPallete.BackGround);
        }
    }

    class ColorPallete
    {
        public static Color Border = new Color(76, 88, 68, 255);
        public static Color ButtonLight = new Color(136, 145, 128, 255);
        public static Color ButtonDark = new Color(40, 46, 34, 255);
        public static Color BackGround = new Color(62, 70, 55, 255);
    }
}
