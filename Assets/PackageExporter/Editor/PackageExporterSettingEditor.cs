
using UnityEngine;
using UnityEditor;

namespace PackageExporter.Editor
{
    [CustomEditor(typeof(PackageExporterSetting)), CanEditMultipleObjects]
    internal sealed class PackageExporterSettingEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This data is used by the Package Exporter, so please do not delete it.", MessageType.Info);
            GUI.enabled = false;
            DrawDefaultInspector();
            GUI.enabled = true;
        }
    }

}