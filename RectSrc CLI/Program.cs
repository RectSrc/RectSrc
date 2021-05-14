using System;
using RectSrc.Builder;

namespace RectSrc.CLI
{
    static class Program
    {
        static void Main(string[] args)
        {
            if(args.Length <= 0)
            {
                Console.WriteLine("RectSrc CLI");
                Console.WriteLine("Commands:");
                Console.WriteLine("info");
                Console.WriteLine("help");
                return;
            }
            switch (args[0].ToLower())
            {
                case "info":
                    Info();
                    break;
                case "help":
                    Help();
                    break;
                default:
                    break;
            }
        }

        static void Info()
        {
            Console.WriteLine("RectSrc CLI");
            Console.WriteLine("Running verison: " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version);
        }

        static void Help()
        {
            Console.WriteLine("RectSrc CLI");
            Console.WriteLine("Help is going to be added later");
        }
    }
}
