using Battle.EventBus.Entities.Common.Components;
using Entities;
using UnityEngine;

namespace Battle.EventBus.Game.Pipeline.Visual.Tasks
{
    public sealed class MoveVisualTask : Task
    {
        private readonly float _duration;
        private readonly Vector3 _position;
        private readonly TransformComponent _transform;

        public MoveVisualTask(IEntity entity, Vector3 position, float duration = 0.15f)
        {
            _transform = entity.Get<TransformComponent>();
            _position = position;
            _duration = duration;
        }

        protected override void OnRun()
        {
            //_transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
    }
}