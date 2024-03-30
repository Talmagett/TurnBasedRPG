using PrimeTween;
using UnityEngine;

namespace Battle.EventBus.Game.Pipeline.Visual.Tasks
{
    public class PlayParticleTask : Task
    {
        private readonly ParticleSystem _particle;
        private readonly Vector3 _position;

        public PlayParticleTask(Vector3 position, ParticleSystem particle)
        {
            _position = position;
            _particle = particle;
        }

        protected override void OnRun()
        {
            var particle = Object.Instantiate(_particle.gameObject, _position, Quaternion.identity);

            Finish();
            Tween.Delay(2, () => { Object.Destroy(particle); });
            //_transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
    }
}