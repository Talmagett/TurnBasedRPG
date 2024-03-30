using Entities;
using EventBus.Entities.Common.Components;
using UnityEngine;

namespace EventBus.Game.Pipeline.Visual.Tasks
{
    public sealed class ScaleChangeVisualTask : Task
    {
        private readonly TransformComponent _transform;
        private readonly Vector3 _scale;
        private readonly float _duration;

        public ScaleChangeVisualTask(IEntity entity, Vector3 scale, float duration = 0.15f)
        {
            _transform = entity.Get<TransformComponent>();
            _scale = scale;
            _duration = duration;
        }

        protected override void OnRun()
        {
            //_transform.Value.DOScale(_scale, _duration).OnComplete(Finish);
        }
    }
}