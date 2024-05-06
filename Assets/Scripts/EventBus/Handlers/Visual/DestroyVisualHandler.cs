using Battle;
using Battle.Actors;
using EventBus.Events;
using JetBrains.Annotations;

namespace EventBus.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class DestroyVisualHandler : BaseHandler<DestroyEvent>
    {
        private readonly BattleContainer _battleContainer;

        public DestroyVisualHandler(BattleContainer battleContainer)
        {
            _battleContainer = battleContainer;
        }
        protected override void HandleEvent(DestroyEvent evt)
        {
            _battleContainer.RemoveUnit(evt.Entity as ActorData);
        }
    }
}

