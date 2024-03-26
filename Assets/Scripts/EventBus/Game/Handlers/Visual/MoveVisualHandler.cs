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
        }
    }
}