using Battle;
using Battle.EventBus.Game;

namespace Game
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance { get; private set; }
        public readonly EventBus EventBus;
        public readonly BattleController BattleController;

        public ServiceLocator(EventBus eventBus, BattleController battleController)
        {
            EventBus = eventBus;
            BattleController = battleController;
            Instance = this;
        }
    }
}