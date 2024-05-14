using Character.Enemies;
using Cysharp.Threading.Tasks;
using EventBus.Events;
using JetBrains.Annotations;
using Modules.Entities.Scripts;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public class StartTurnEventHandler : BaseHandler<StartTurnEvent>
    {
        protected override void HandleEvent(StartTurnEvent evt)
        {
            Run(evt.Source).Forget();
            EventBus.RaiseEvent(new TurnSelectionEvent(evt.Source, true));
        }

        private async UniTask Run(IEntity entity)
        {
            await UniTask.Delay(750);
            if (entity.TryGet(out EnemyAI enemyAI))
                enemyAI.Run();
        }
    }
}