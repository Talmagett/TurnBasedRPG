using Battle;
using Battle.Actors;
using EventBus.Events;
using JetBrains.Annotations;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DestroyAtomicHandler : BaseHandler<DestroyAtomicEvent>
    {
        private readonly BattleContainer _battleContainer;

        public DestroyAtomicHandler(BattleContainer battleContainer)
        {
            _battleContainer = battleContainer;
        }
        protected override void HandleEvent(DestroyAtomicEvent evt)
        {
            if(evt.Entity is ActorData actorData)
                _battleContainer.RemoveUnit(actorData);
        }
    }
}

