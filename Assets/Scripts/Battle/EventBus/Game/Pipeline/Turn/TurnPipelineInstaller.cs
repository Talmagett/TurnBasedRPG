using System;
using EventBus.Game.Pipeline.Turn.Tasks;
using EventBus.Game.Pipeline.Visual;
using JetBrains.Annotations;
using Zenject;

namespace EventBus.Game.Pipeline.Turn
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
            //_turnPipeline.AddTask(new PlayerTurnTask(eventBus));
            _turnPipeline.AddTask(new HandleVisualPipelineTask(visualPipeline));
            _turnPipeline.AddTask(new FinishTurnTask());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.Clear();
        }
    }
}