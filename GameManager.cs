using System;
using System.Collections.Generic;
using System.Text;
using RectSrc;
using RectSrc.Core;
using System.Reflection;
namespace RectSrc.Game
{
    public static class GameManager
    {

        public static void UpdateAll()
        {
            for (int i = 0; i < MainProgram.classes.Count; i++)
            {
                if (MainProgram.classes[i].classType == ClassType.Script)
                {
                    foreach (var function in MainProgram.classes[i].type.GetMethods(BindingFlags.Static | BindingFlags.Public))
                    {
                        if(function.Name == "Update")
                        {
                            MainProgram.classes[i].type.GetMethod("Update").Invoke(null, null);
                        }
                    }
                }
            }
        }

        public static void StartAll()
        {
            for (int i = 0; i < MainProgram.classes.Count; i++)
            {
                if (MainProgram.classes[i].classType == ClassType.Script)
                {
                    foreach (var function in MainProgram.classes[i].type.GetMethods(BindingFlags.Static | BindingFlags.Public))
                    {
                        if (function.Name == "Start")
                        {
                            MainProgram.classes[i].type.GetMethod("Start").Invoke(null, null);
                        }
                    }
                }
            }
        }

        public static void GameLoop()
        {
            StartAll();
            while (true)
            {
                UpdateAll();
            }
        }

    }
}
