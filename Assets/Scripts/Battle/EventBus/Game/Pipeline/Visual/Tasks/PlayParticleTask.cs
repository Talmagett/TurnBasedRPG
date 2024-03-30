using PrimeTween;
using UnityEngine;

namespace EventBus.Game.Pipeline.Visual.Tasks
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
        
        protected override void OnRun()
        {
            var particle = GameObject.Instantiate(_particle.gameObject, _position, Quaternion.identity);

            Finish();
            Tween.Delay(duration: 2, () =>
            {
                GameObject.Destroy(particle);
            });
            //_transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
    }
}