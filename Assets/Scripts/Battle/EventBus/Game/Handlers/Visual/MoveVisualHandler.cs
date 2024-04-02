using Battle.EventBus.Game.Events;
using Battle.EventBus.Game.Pipeline.Visual;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class MoveVisualHandler : BaseVisualHandler<MoveEvent>
    {
        public MoveVisualHandler(EventBus eventBus,
            VisualPipeline visualPipeline) : base(eventBus, visualPipeline)
        {
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            /*var position = _levelMap.Tiles.CoordinatesToPosition(evt.Coordinates);
            VisualPipeline.AddTask(new MoveVisualTask(evt.Entity, position));
*/
            //raise event, attack
            /*var target = BattleController.PlayerSide.GetRandom();
            var basePosition = transform.position;
            var targetPosition = target.transform.position;
            var targetDirection = (targetPosition - basePosition).normalized;
            targetPosition -= targetDirection * target.GetVariable<float>("CollisionRadius").Value;
            await Tween.Position(transform, targetPosition, 0.6f,ease:Ease.OutCirc);
            //target.TakeDamage(stats.Value.physicalPower.Value);
            await UniTask.Delay(500);
            if (this == null)
                return;
            await Tween.Position(transform, basePosition, 0.4f,ease:Ease.OutCirc);*/
        }
    }
}