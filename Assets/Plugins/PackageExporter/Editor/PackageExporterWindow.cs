
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace PackageExporter.Editor
{
    internal class PackageExporterWindow : EditorWindow
    {
        [MenuItem("Window/Test Export Package")]
        public static void ShowWindow()
        {
            var window = GetWindow<PackageExporterWindow>();
            window.titleContent = new GUIContent("Package Exporter Window");
            window.Show();
        }
        
        string _assetsFolderPath;
        GUIContent _folderIcon;

        void OnEnable()
        {
            _assetsFolderPath = PackageExporterSetting.Instance.FolderPath;
            _folderIcon = EditorGUIUtility.IconContent("Folder Icon");
        }
        
        void OnGUI()
        {
            {
                var style = new GUIStyle(GUI.skin.label)
                {
                    padding = new RectOffset(5, 5, 5, 5),
                    alignment = TextAnchor.MiddleCenter,
                    fontSize = 16,
                };
                GUILayout.Label("Test Export Package", style, GUILayout.MinWidth(430), GUILayout.Height(60));
            }
            
            EditorGUILayout.HelpBox("Please select a directory under the Assets folder for the package.", MessageType.Info);
            GUILayout.Space(5);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Assets Folder", GUILayout.MaxWidth(90));
            _assetsFolderPath = GUILayout.TextField(_assetsFolderPath);
            var buttonClicked = GUILayout.Button(_folderIcon, GUILayout.Width(35), GUILayout.Height(EditorGUIUtility.singleLineHeight));
            GUILayout.EndHorizontal();

            if (buttonClicked)
            {
                var selectedPath = EditorUtility.OpenFolderPanel(
                    "Select assets folder",
                    string.IsNullOrEmpty(_assetsFolderPath)
                        ? "Assets/"
                        : _assetsFolderPath,
                    "Select assets folder");
                
                if (!string.IsNullOrEmpty(selectedPath)
                    && _assetsFolderPath != selectedPath)
                {
                    Undo.RecordObject(this, "assets folder Update");
                    
                    _assetsFolderPath = selectedPath;
                    var assetsIndex = _assetsFolderPath.IndexOf("Assets", StringComparison.Ordinal);
                    if (assetsIndex >= 0)
                    {
                        _assetsFolderPath = _assetsFolderPath.Substring(assetsIndex);
                        if (!string.IsNullOrEmpty(_assetsFolderPath)
                            && !_assetsFolderPath.EndsWith('/'))
                        {
                            _assetsFolderPath += "/";
                        }
                    }
                    else
                    {
                        _assetsFolderPath = string.Empty;
                        Debug.LogError("Please select the directory path under Assets.");
                    }
                    
                    PackageExporterSetting.Instance.SetFolderPath(_assetsFolderPath);
                    EditorUtility.SetDirty(this);
                }
            }
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Export Package", GUILayout.Height(35))
                && ValidDirectory(_assetsFolderPath))
            {
                Builder.Build(_assetsFolderPath, "Test.unitypackage");
            }
        }
        
        static bool ValidDirectory(string dir, bool showError = true)
        {
            if (string.IsNullOrEmpty(dir))
            {
                if (showError)
                {
                    Debug.LogError("Directory path is empty. Please set it.");
                }
                return false;
            }
            if (!dir.StartsWith("Assets/"))
            {
                if (showError)
                {
                    Debug.LogError("Please specify the contents under the Assets/ directory. " + dir);
                }
                return false;
            }
            if (!File.Exists(dir.TrimEnd('/') + "/" + "package.json"))
            {
                if (showError)
                {
                    Debug.LogError("Please specify the package directory: " + dir);
                }
                return false;
            }
            if (Path.HasExtension(dir))
            {
                if (showError)
                {
                    Debug.LogError("Please specify a directory for the path. " + dir);
                }
                return false;
            }
            return true;
        }
    }
}