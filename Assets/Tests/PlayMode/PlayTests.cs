#if UNITY_EDITOR
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTests
    {
        [UnityTest]
        public IEnumerator SamplePlayTest1()
        {
            yield return null;
            Assert.That(2 * 2, Is.EqualTo(4), "2 * 2 should equal 4");
        }

        [UnityTest]
        public IEnumerator SamplePlayTest2()
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            Assert.That(cube, Is.Not.Null, "Cube should have a position");
        }

        [UnityTest]
        public IEnumerator SamplePlayTest3()
        {
            var player = new GameObject("Player");
            player.AddComponent<Rigidbody>();
            yield return new WaitForFixedUpdate();
            Assert.That(player.GetComponent<Rigidbody>(), Is.Not.Null, "Player should have a Rigidbody component.");
        }

        [UnityTest]
        public IEnumerator SamplePlayTest4()
        {
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Object.Destroy(sphere);
            yield return null;
            Assert.That(sphere == default, Is.True, "Sphere should be destroyed after one frame.");
        }
    }
}
#endif