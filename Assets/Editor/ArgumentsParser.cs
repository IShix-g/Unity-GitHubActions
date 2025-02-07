// https://github.com/Cysharp/UniTask/blob/master/src/UniTask/Assets/Editor/PackageExporter.cs
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityBuilderAction.Input
{
    public class ArgumentsParser
    {
        static string EOL = Environment.NewLine;
        static readonly string[] Secrets = { "androidKeystorePass", "androidKeyaliasName", "androidKeyaliasPass" };

        public static Dictionary<string, string> GetValidatedOptions()
        {
            Dictionary<string, string> validatedOptions;
            ParseCommandLineArguments(out validatedOptions);

            if (!validatedOptions.TryGetValue("customBuildPath", out var buildsPath))
            {
                PrintErrorLog("Please pass a customBuildPath to with. customBuildPath: build");
            }
            
            if (!validatedOptions.TryGetValue("tag", out var tag))
            {
                PrintErrorLog("Please pass a tag to customParameters. customParameters: -tag 1.0.0");
            }
            
            return validatedOptions;
        }

        static void ParseCommandLineArguments(out Dictionary<string, string> providedArguments)
        {
            providedArguments = new Dictionary<string, string>();
            string[] args = Environment.GetCommandLineArgs();

            Console.WriteLine(
                EOL +
                "###########################" + EOL +
                "#    Parsing settings     #" + EOL +
                "###########################" + EOL +
                EOL
            );

            // Extract flags with optional values
            for (int current = 0, next = 1; current < args.Length; current++, next++) {
                // Parse flag
                bool isFlag = args[current].StartsWith("-");
                if (!isFlag) continue;
                string flag = args[current].TrimStart('-');

                // Parse optional value
                bool flagHasValue = next < args.Length && !args[next].StartsWith("-");
                string value = flagHasValue ? args[next].TrimStart('-') : "";
                bool secret = Secrets.Contains(flag);
                string displayValue = secret ? "*HIDDEN*" : "\"" + value + "\"";

                // Assign
                Console.WriteLine("Found flag \"" + flag + "\" with value " + displayValue);
                providedArguments.Add(flag, value);
            }
        }
        
        public static void PrintErrorLog(string msg)
        {
            if (Application.isBatchMode)
            {
                Console.WriteLine($"::error:: {msg}");
                EditorApplication.Exit(1);
            }
            else Debug.LogError(msg);
        }
    }
}