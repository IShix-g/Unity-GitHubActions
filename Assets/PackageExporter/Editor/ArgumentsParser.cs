// https://github.com/game-ci/documentation/blob/main/example/BuildScript.cs
using System;
using System.Collections.Generic;
using UnityEditor;

namespace PackageExporter.Editor
{
    internal class ArgumentsParser
    {
        static readonly string s_eol = Environment.NewLine;
        
        public static Dictionary<string, string> GetValidatedOptions()
        {
            ParseCommandLineArguments(out var validatedOptions);
            
            if (!validatedOptions.TryGetValue("projectPath", out string _))
            {
                Console.WriteLine("Missing argument -projectPath");
                EditorApplication.Exit(110);
            }
            if (!validatedOptions.TryGetValue("buildTarget", out string buildTarget))
            {
                Console.WriteLine("Missing argument -buildTarget");
                EditorApplication.Exit(120);
            }
            if (!Enum.IsDefined(typeof(BuildTarget), buildTarget ?? string.Empty))
            {
                Console.WriteLine($"{buildTarget} is not a defined {nameof(BuildTarget)}");
                EditorApplication.Exit(121);
            }
            if (!validatedOptions.TryGetValue("customBuildPath", out string _))
            {
                Console.WriteLine("Missing argument -customBuildPath");
                EditorApplication.Exit(130);
            }
            if (!validatedOptions.TryGetValue("customBuildName", out string _))
            {
                Console.WriteLine("Missing argument -customBuildName");
                EditorApplication.Exit(131);
            }
            return validatedOptions;
        }

        static void ParseCommandLineArguments(out Dictionary<string, string> providedArguments)
        {
            providedArguments = new Dictionary<string, string>();
            var args = Environment.GetCommandLineArgs();

            Console.WriteLine(
                $"{s_eol}" +
                $"###########################{s_eol}" +
                $"#    Parsing settings     #{s_eol}" +
                $"###########################{s_eol}" +
                $"{s_eol}"
            );
            
            for (int current = 0, next = 1; current < args.Length; current++, next++)
            {
                var isFlag = args[current].StartsWith("-");
                if (!isFlag)
                {
                    continue;
                }
                var flag = args[current].TrimStart('-');
                var flagHasValue = next < args.Length && !args[next].StartsWith("-");
                var value = flagHasValue ? args[next].TrimStart('-') : "";
                var displayValue = "\"" + value + "\"";
                Console.WriteLine($"Found flag \"{flag}\" with value {displayValue}.");
                providedArguments.Add(flag, value);
            }
        }
    }
}