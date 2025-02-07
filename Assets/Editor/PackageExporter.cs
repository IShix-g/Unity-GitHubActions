
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
    const string _exportPath = "TestExportPackage_{version}.unitypackage";
    static string _eol = Environment.NewLine;
    
    [MenuItem("Tools/Export Unitypackage")]
    public static void ExportTest() => Export(_folderPath, ToExportPath(_exportPath, "1.0.0"));

    public static void Export()
    {
        var options = ArgumentsParser.GetValidatedOptions();
        var buildPath = options.GetValueOrDefault("customBuildPath")?.TrimEnd('/');
        var exportPath = "./" + (!string.IsNullOrEmpty(buildPath) ? buildPath + "/" : "") + ToExportPath(_exportPath, options.GetValueOrDefault("tag"));
        Export(_folderPath, exportPath);
    }

    public static void Export(string folderPath, string exportPath)
    {
        var assets = AssetDatabase.FindAssets("", new[] { folderPath })
                .Select(AssetDatabase.GUIDToAssetPath)
                .ToArray();
        
        PrintLog("Export below files" + _eol + string.Join(_eol, assets));

        AssetDatabase.ExportPackage(
            assets,
            exportPath,
            ExportPackageOptions.Default);

        PrintLog("Export complete: " + Path.GetFullPath(exportPath));
    }
    
    static string ToExportPath(string exportPath, string tag) => exportPath.Replace("{version}", tag);
    
    static void PrintLog(string msg)
    {
        if (Application.isBatchMode) Console.WriteLine(msg);
        else Debug.Log(msg);
    }
    

}