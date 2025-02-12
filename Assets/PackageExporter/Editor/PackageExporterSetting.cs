
using UnityEngine;
using UnityEditor;

namespace PackageExporter.Editor
{
    internal sealed class PackageExporterSetting : ScriptableObject
    {
        public const string AssetPath = "Assets/Editor/PackageExporterSetting.asset";
        
        [SerializeField] string _folderPath;
        [SerializeField] bool _isCompletedTest;

        public string FolderPath
        {
            get => _folderPath;
            set
            {
                _folderPath = value;
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssetIfDirty(this);
            }
        }

        public bool IsCompletedTest
        {
            get => _isCompletedTest;
            set
            {
                _isCompletedTest = value;
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssetIfDirty(this);
            }
        }
        
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
    }
}