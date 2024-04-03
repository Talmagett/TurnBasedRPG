using Atomic.Objects;
using Battle.EventBus.Entities.Common.Components;
using Configs.Enums;
using Entities;
using PrimeTween;
using UnityEngine;

namespace Battle.EventBus.Game.Pipeline.Visual.Tasks
{
    public sealed class ScaleChangeVisualTask : Task
    {
        private readonly float _duration;
        private readonly Vector3 _scale;
        private readonly Transform _transform;

        public ScaleChangeVisualTask(IAtomicObject entity, Vector3 scale, float duration = 0.15f)
        {
            _transform = entity.Get<Transform>(AtomicPropertyAPI.TransformKey);
            _scale = scale;
            _duration = duration;
        }

        protected override void OnRun()
        {
            Tween.Scale(_transform, _scale, _duration);
        }
    }
}