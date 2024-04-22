using Atomic.Objects;
using Battle.EventBus.Entities.Common.Components;
using Entities;

namespace Battle.EventBus.Game.Pipeline.Visual.Tasks
{
    public sealed class DestroyVisualTask : Task
    {
        private readonly float _duration;

        public DestroyVisualTask(IAtomicObject entity, float duration = 0.15f)
        {
            _duration = duration;
        }

        protected override void OnRun()
        {
            //_transform.Value.DOScale(Vector3.zero, _duration).OnComplete(Finish);
        }
    }
}