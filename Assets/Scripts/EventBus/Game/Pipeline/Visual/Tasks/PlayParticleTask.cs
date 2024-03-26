using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Lessons.Game.Pipeline.Visual.Tasks
{
    public class PlayParticleTask : Task
    {
        private readonly Vector3 _position;
        private readonly ParticleSystem _particle;

        public PlayParticleTask(Vector3 position, ParticleSystem particle)
        {
            _position = position;
            _particle = particle;
        }
        
        protected override async void OnRun()
        {
            var particle = Object.Instantiate(_particle.gameObject, _position, Quaternion.identity);
            await UniTask.Delay(1000);
            GameObject.Destroy(particle.gameObject);
            Finish();
            //_transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
    }
}