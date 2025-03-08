
using UnityEngine;

namespace Tests
{
    public sealed class TestMonoBehavior : MonoBehaviour
    {
        float _speed = 5f;
        Vector3 _direction = Vector3.forward;

        void Start()
        {
            _direction = _direction.normalized;
        }

        void Update()
        {
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }
    }
}