
using NUnit.Framework;
using UnityEditor;

namespace Tests
{
    public class EditorTests
    {
        [Test]
        public void SampleEditorTest1()
        {
            Assert.That(1 + 1, Is.EqualTo(2), "1 + 1 should equal 2");
        }

        [Test]
        public void SampleEditorTest2()
        {
            var activeScenePath = EditorApplication.currentScene;
            Assert.That(activeScenePath, Is.Not.Null, "There should be an active scene in the editor.");
        }

        [Test]
        public void SampleEditorTest3()
        {
            Assert.That(EditorPrefs.HasKey("EditorTests_SampleEditorTest3_TestKey"), Is.False, "EditorPrefs should have a key.");
        }
    }
}