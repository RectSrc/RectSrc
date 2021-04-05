using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using Mono.Cecil;
using RectSrc.Game;
using System.IO;
namespace RectSrc.Core
{
    public static class MainProgram
    {

        public static List<ClassData> classes = new List<ClassData>();
        public static Assembly ReCTProgram;
        public static string assemblyName = "yay.dll";
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello from ReCTSrc debug log!");
            ReCTProgram = Assembly.LoadFrom(Directory.GetCurrentDirectory() + "/" + assemblyName);
            PrepareCode();

            GameManager.GameLoop();

        }

        public static void PrepareCode()
        {

            foreach (Type type in ReCTProgram.GetTypes())
            {
                //Console.WriteLine(type.FullName);
                if (type.FullName.StartsWith("S_"))
                {
                    classes.Add(new ClassData(type, ClassType.Script));
                }
            }
            foreach(ClassData classData in classes)
            {
                Console.WriteLine(classData.ToString());
            }
        }
    }

    public class ClassData
    {
        public Type type;
        public ClassType classType;

        public override string ToString()
        {
            return "Name: " + type.FullName + ", Type: " + classType.ToString();
        }

        public ClassData(Type type, ClassType classType)
        {
            this.type = type;
            this.classType = classType;
        }
    }

    public enum ClassType
    {
        Script
    }
}
