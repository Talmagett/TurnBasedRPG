using System;
using Components;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Mechanics
{
    public class Projectile:MonoBehaviour
    {
        private UniTaskCompletionSource<Health> _onHitSource;
        private float _speed;
        public async UniTask<Health> Shoot(float speed)
        {
            _onHitSource = new UniTaskCompletionSource<Health>();/**/
            _speed = speed;
            return await _onHitSource.Task;
        }

        private void Update()
        {
            transform.Translate(transform.forward*_speed*Time.deltaTime,Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            print(other.name+" was hit by projectile");
            if (other.transform.TryGetComponent(out Health health))
            {
                _onHitSource.TrySetResult(health);
            }
        }
    }
}