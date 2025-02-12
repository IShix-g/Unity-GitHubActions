
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace PackageExporter.Editor
{
    internal sealed class Builder
    {
        public static void Build()
        {
            var assetsFolderPath = PackageExporterSetting.Instance.FolderPath;
            var isCompletedTest = PackageExporterSetting.Instance.IsCompletedTest;
            if (!string.IsNullOrWhiteSpace(assetsFolderPath) && isCompletedTest)
            {
                var options = ArgumentsParser.GetValidatedOptions();
                var buildPath = options.GetValueOrDefault("customBuildPath");
                Build(assetsFolderPath, buildPath);
            }
            else
            {
                PrintErrorLog("Please perform a package export test in Unity first. Go to Window > Test Export Package.");
            }
        }

        public static void Build(string assetsFolderPath, string buildPath)
        {
            var assets = AssetDatabase.FindAssets("", new[] {assetsFolderPath})
                .Select(AssetDatabase.GUIDToAssetPath)
                .ToArray();

            PrintLog("Export below files" + Environment.NewLine + string.Join(Environment.NewLine, assets));

            AssetDatabase.ExportPackage(
                assets,
                buildPath,
                ExportPackageOptions.Default);

            if (File.Exists(buildPath))
            {
                var message = "Export complete: " + Path.GetFullPath(buildPath);
                if (Application.isBatchMode)
                {
                    message = "::notice title=Unity Editor::" + message;
                }
                PrintLog(message);
            }
            else
            {
                PrintErrorLog("Export failed: " + Path.GetFullPath(buildPath));
            }
        }

        static void PrintLog(string msg)
        {
            if (Application.isBatchMode) Console.WriteLine(msg);
            else Debug.Log(msg);
        }

        public static void PrintErrorLog(string msg)
        {
            if (Application.isBatchMode)
            {
                Console.WriteLine($"::error::{msg}");
                EditorApplication.Exit(1);
            }
            else Debug.LogError(msg);
        }
    }
}