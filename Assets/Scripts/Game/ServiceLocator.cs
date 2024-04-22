using Battle;
using Battle.EventBus.Game;

namespace Game
{
    public class ServiceLocator
    {
        public readonly BattleController BattleController;
        public readonly EventBus EventBus;

        public ServiceLocator(EventBus eventBus, BattleController battleController)
        {
            EventBus = eventBus;
            BattleController = battleController;
            Instance = this;
        }

        public static ServiceLocator Instance { get; private set; }
    }
}