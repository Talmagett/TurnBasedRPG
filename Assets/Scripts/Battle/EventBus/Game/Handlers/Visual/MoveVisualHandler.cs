using EventBus.Game.Events;
using EventBus.Game.Pipeline.Visual;
using EventBus.Game.Pipeline.Visual.Tasks;
using EventBus.Level;
using JetBrains.Annotations;
using UnityEngine;

namespace EventBus.Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class MoveVisualHandler : BaseVisualHandler<MoveEvent>
    {
        private readonly LevelMap _levelMap;
        
        public MoveVisualHandler(EventBus eventBus, 
            VisualPipeline visualPipeline, LevelMap levelMap) : base(eventBus, visualPipeline)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            Vector3 position = _levelMap.Tiles.CoordinatesToPosition(evt.Coordinates);
            VisualPipeline.AddTask(new MoveVisualTask(evt.Entity, position));
            
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