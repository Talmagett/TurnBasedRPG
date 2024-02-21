using System;
using System.Threading;
using Battle.Core;
using Components;
using Components.Stats;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Mechanics
{
    public class Projectile : MonoBehaviour
    {
        private UniTaskCompletionSource<Health> _onHitSource;
        private float _speed;
        private BattleUnit _owner;
        public async UniTask<Health> Shoot(float speed, float lifeTime, BattleUnit owner)
        {
            _onHitSource = new UniTaskCompletionSource<Health>();
            _speed = speed;
            _owner = owner;
            LifeTime(lifeTime,new CancellationTokenSource()).Forget();
            return await _onHitSource.Task;
        }

        private async UniTask LifeTime(float lifeTime,CancellationTokenSource cts)
        {
            await UniTask.WaitForSeconds(lifeTime);
            _onHitSource.TrySetResult(null);
        }

        private void Update()
        {
            transform.Translate(transform.forward*_speed*Time.deltaTime,Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == _owner.transform)
                return;
            if (!other.transform.TryGetComponent(out Team team)) 
                return;
            if (_owner.IsPlayer() == team.IsPlayer)
                return;
            if (!other.transform.TryGetComponent(out Health health)) 
                return;
            
            _onHitSource.TrySetResult(health);
        }
    }
}