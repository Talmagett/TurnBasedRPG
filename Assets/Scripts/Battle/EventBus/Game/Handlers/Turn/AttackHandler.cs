using Battle.EventBus.Entities.Common.Components;
using Battle.EventBus.Game.Events;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(AttackEvent evt)
        {
            if (!evt.Entity.TryGet(out WeaponComponent weaponComponent))
                return;

            foreach (var effect in weaponComponent.Value.Effects)
            {
                effect.Source = evt.Entity;
                effect.Target = evt.Target;

                EventBus.RaiseEvent(effect);
            }
        }
    }
}