
using UnityEngine;
using UnityEditor;

namespace PackageExporter.Editor
{
    internal sealed class PackageExporterSetting : ScriptableObject
    {
        public const string AssetPath = "Assets/Editor/PackageExporterSetting.asset";
        
        [SerializeField] string _folderPath;
        
        public string FolderPath => _folderPath;
        
        public static PackageExporterSetting Instance
        {
            get
            {
                if (s_instance == default)
                {
                    s_instance = AssetDatabaseSupport.CreateOrLoad<PackageExporterSetting>(AssetPath);
                }
                return s_instance;
            }
        }
        static PackageExporterSetting s_instance;

        public void SetFolderPath(string path)
        {
            _folderPath = path;
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssetIfDirty(this);
        }
    }
}