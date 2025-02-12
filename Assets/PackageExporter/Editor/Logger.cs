
using System;
using UnityEngine;
using UnityEditor;

namespace PackageExporter.Editor
{
    public static class Logger
    {
        public static void Log(string msg)
        {
            if (Application.isBatchMode) Console.WriteLine(msg);
            else Debug.Log(msg);
        }

        public static void Notice(string msg)
        {
            if (Application.isBatchMode)
            {
                Console.WriteLine($"::notice title=UnityEditor::{msg}");
            }
            else Debug.Log(msg);
        }
        
        public static void Warning(string msg)
        {
            if (Application.isBatchMode)
            {
                Console.WriteLine($"::warning title=UnityEditor::{msg}");
            }
            else Debug.LogError(msg);
        }
        
        public static void Error(string msg)
        {
            if (Application.isBatchMode)
            {
                Console.WriteLine($"::error title=UnityEditor::{msg}");
                EditorApplication.Exit(1);
            }
            else Debug.LogError(msg);
        }
    }
}