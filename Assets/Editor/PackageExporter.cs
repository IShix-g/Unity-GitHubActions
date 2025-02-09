
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityBuilderAction.Input;
using UnityEditor;
using UnityEngine;

public sealed class PackageExporter
{
    const string _folderPath = "Assets/Plugins/TestExportPackage";
    
    [MenuItem("Tools/Export Unitypackage")]
    public static void ExportTest() => Export(_folderPath, "Test.unitypackage");

    public static void Export()
    {
        var options = ArgumentsParser.GetValidatedOptions();
        var buildPath = options.GetValueOrDefault("customBuildPath");
        buildPath = buildPath?.Replace("/github/workspace/", "");
        Export(_folderPath, buildPath);
    }

    public static void Export(string folderPath, string exportPath)
    {
        var assets = AssetDatabase.FindAssets("", new[] { folderPath })
                .Select(AssetDatabase.GUIDToAssetPath)
                .ToArray();
        
        PrintLog("Export below files" + Environment.NewLine + string.Join(Environment.NewLine, assets));
        
        AssetDatabase.ExportPackage(
            assets,
            exportPath,
            ExportPackageOptions.Default);

        if (File.Exists(exportPath))
        {
            PrintLog("Export complete: " + Path.GetFullPath(exportPath));
        }
        else
        {
            PrintErrorLog("Export failed: " + Path.GetFullPath(exportPath));
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
            Console.WriteLine($"::error:: {msg}");
            EditorApplication.Exit(1);
        }
        else Debug.LogError(msg);
    }
}