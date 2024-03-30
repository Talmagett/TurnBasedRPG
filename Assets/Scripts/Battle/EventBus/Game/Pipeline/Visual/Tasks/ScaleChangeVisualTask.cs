using Battle.EventBus.Entities.Common.Components;
using Entities;
using UnityEngine;

namespace Battle.EventBus.Game.Pipeline.Visual.Tasks
{
    public sealed class ScaleChangeVisualTask : Task
    {
        private readonly float _duration;
        private readonly Vector3 _scale;
        private readonly TransformComponent _transform;

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