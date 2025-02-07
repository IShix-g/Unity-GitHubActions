#if UNITY_EDITOR
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public sealed class PlayTests2
    {
        [UnityTest]
        public IEnumerator LightComponentExistsTest()
        {
            var lightObject = new GameObject("TestLight");
            var lightComponent = lightObject.AddComponent<Light>();

            yield return null;

            Assert.That(lightComponent, Is.Not.Null, "The GameObject should have a Light component.");
        }
        
        [UnityTest]
        public IEnumerator RigidbodyGravityTest()
        {
            var obj = new GameObject("TestObject");
            var rb = obj.AddComponent<Rigidbody>();
            rb.useGravity = true;

            yield return new WaitForFixedUpdate();

            Assert.That(rb.useGravity, Is.True, "Rigidbody should have gravity enabled.");
        }
        
        [UnityTest]
        public IEnumerator GameObjectScaleChangeTest()
        {
            var obj = new GameObject("TestObject");
            obj.transform.localScale = Vector3.one;

            yield return null;

            obj.transform.localScale = new Vector3(2f, 2f, 2f);

            Assert.That(obj.transform.localScale.x, Is.EqualTo(2f), "The GameObject's X scale should be 2.");
            Assert.That(obj.transform.localScale.y, Is.EqualTo(2f), "The GameObject's Y scale should be 2.");
            Assert.That(obj.transform.localScale.z, Is.EqualTo(2f), "The GameObject's Z scale should be 2.");
        }
        
        [UnityTest]
        public IEnumerator GameObjectResetPositionTest()
        {
            var obj = new GameObject("TestObject");
            obj.transform.position = new Vector3(10f, 5f, -3f);

            yield return null;

            obj.transform.position = Vector3.zero;

            Assert.That(obj.transform.position, Is.EqualTo(Vector3.zero), "The GameObject's position should be reset to Vector3.zero.");
        }

    }
}
#endif