using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using ShellProgressBar;

namespace RectSrc.Builder
{
    public static class RectSrcBuilder
    {
        public static string currentDirectory;
        public static string runMain =
@"
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.IO;
using RectSrc.Core.Game;
using RectSrc.Core.Game.Entities;
using RectSrc.Core.IO;
namespace RectSrc.Bin
{
    public static class MainProgram
    {
        public static void Main(string[] args)
        {
            GameData game = GameLoader.LoadGame(Directory.GetCurrentDirectory() +  ""/engine/static/data.rsg"");
            GameManager.Run(game.levels[0]);
        }
    }
}
";

        public static string buildMain =
@"
using System; 
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.IO;
using RectSrc.Core.Game;
using RectSrc.Core.Game.Entities;
using RectSrc.Core.IO;
using RectSrc.Core.Math;
namespace RectSrc.Bin
{
    public static class MainProgram
    {
        public static void Main(string[] args)
        {
            Level level = new Level();
            level.name = ""test"";
            level.entities.Add(new Camera(Vector3.one* 10));
            level.entities.Add(new Cube(Vector3.zero));
            GameData game = new GameData(""Cubeisthebest"");
            game.levels.Add(level);
            GameLoader.SaveGame(game);
        }
    }
}
";

        public static void Build(string path)
        {
            Main(new string[] {"build", path});
        }


        public static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("RectSrc builder CLI");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No command entered, enter command help for info");
                Console.ResetColor();
                return;
            }

            if (args[0] == "help")
                ShowHelp();
            if (args[0] == "build")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("RectSrc builder - build game");
                Console.ResetColor();
                if (args.Length < 2)
                    RaiseError("No location specified, more info with command help");
                string gamePath = args[1];
                Console.WriteLine("Path specified is \"" + args[1] + "\"");
                Console.Write("Checking path...");
                if (!Directory.Exists(gamePath))
                    RaiseError("\nInvalid location \"" + gamePath + "\"");
                ClearCurrentConsoleLine();
                SucessMsg("Valid path");

                int steps = 4;
                var options = new ProgressBarOptions
                {
                    EnableTaskBarProgress = true,
                    ShowEstimatedDuration = true,
                    ForegroundColor = ConsoleColor.White,
                    ForegroundColorDone = ConsoleColor.Green,
                    DisplayTimeInRealTime = false,
                    DisableBottomPercentage = false
                    
                };

                //ProgressBar progressBar = new ProgressBar(steps, "Building", options);
                Console.WriteLine("Building base project...");
                File.WriteAllText(gamePath + "/Main.cs", buildMain);
                //progressBar.Tick();
                RunCmd("dotnet build " + gamePath + "/RectSrc.csproj");
                //progressBar.Tick();
                string currentDir = Directory.GetCurrentDirectory();
                Console.WriteLine("Generating files...");
                RunCmd("cd " + gamePath + "/bin/Debug/netcoreapp3.1 && RectSrc && cd " +currentDir);
                //RunCmd(gamePath + "/Debug/netcoreapp3.1/RectSrc.exe");
                Console.WriteLine("Building player...");
                File.WriteAllText(gamePath + "/Main.cs", runMain);
                RunCmd("dotnet build " + gamePath + "/RectSrc.csproj");
            }
        }

        public static void RunCmd(string command)
        {
            System.Diagnostics.Process.Start("CMD.exe", "/C " + command).WaitForExit();
        }

        public static void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RectSrc builder CLI");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Usage: [command] [location] [destination]");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commands:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\tbuild - builds a game from the location to the destination, destination is set to the subfolder build if not specified");
            Console.WriteLine("\thelp - shows this message");

            Console.ResetColor();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void RaiseError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
            Environment.Exit(0);

        }

        public static void SucessMsg(string error)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(error);
            Console.ResetColor();

        }
    }
}
