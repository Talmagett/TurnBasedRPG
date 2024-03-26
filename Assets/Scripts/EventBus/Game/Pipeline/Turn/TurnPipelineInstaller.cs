using System;
using JetBrains.Annotations;
using Lessons.Game.Pipeline.Turn.Tasks;
using Lessons.Game.Pipeline.Visual;
using Zenject;

namespace Lessons.Game.Pipeline.Turn
{
    [UsedImplicitly]
    public sealed class TurnPipelineInstaller : IInitializable, IDisposable
    {
        private readonly TurnPipeline _turnPipeline;
        private readonly DiContainer _diContainer;

        public TurnPipelineInstaller(TurnPipeline turnPipeline,DiContainer diContainer)
        {
            _turnPipeline = turnPipeline;
            _diContainer = diContainer;
        }

        void IInitializable.Initialize()
        {
            var eventBus = _diContainer.Resolve<EventBus>();
            var visualPipeline = _diContainer.Resolve<VisualPipeline>();
            _turnPipeline.AddTask(new StartTurnTask());
            _turnPipeline.AddTask(new PlayerTurnTask(eventBus));
            _turnPipeline.AddTask(new HandleVisualPipelineTask(visualPipeline));
            _turnPipeline.AddTask(new FinishTurnTask());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.Clear();
        }
    }
}