
using NUnit.Framework;
using UnityEditor;

namespace Tests
{
    public sealed class EditorTests2
    {
        [Test]
        public void BasicMathTest()
        {
            Assert.That(5 * 2, Is.EqualTo(10), "5 multiplied by 2 should equal 10.");
        }
        
        [Test]
        public void EditorPrefsTest()
        {
            var testKey = "SampleTestKey";
            var testValue = "SampleValue";
            
            EditorPrefs.SetString(testKey, testValue);

            Assert.That(EditorPrefs.HasKey(testKey), Is.True, "EditorPrefs should contain the key.");
            Assert.That(EditorPrefs.GetString(testKey), Is.EqualTo(testValue), "EditorPrefs should return the correct value.");

            EditorPrefs.DeleteKey(testKey);
            Assert.That(EditorPrefs.HasKey(testKey), Is.False, "EditorPrefs key should be deleted.");
        }
    }
}