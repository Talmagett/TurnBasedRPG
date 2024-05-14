using Game.Gameplay.EventBus.Events;
using JetBrains.Annotations;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class MoveHandler : BaseHandler<MoveEvent>
    {
        protected override void HandleEvent(MoveEvent evt)
        {
            evt.Transform.position += evt.DeltaDirection;
        }
    }
}