using Battle;
using UnityEngine;
using Visual.UI;
using Zenject;

namespace Game
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private BattleController battleController;
        [SerializeField] private UIController uiController;

        public override void InstallBindings()
        {
            Container.BindInstance(gameStateController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.BindInstance(uiController).AsSingle();
            Container.Bind<ServiceLocator>().AsSingle().NonLazy();
        }
    }
}