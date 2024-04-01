using Battle;
using Configs;
using UnityEngine;
using Zenject;

namespace Game
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private BattleController battleController;

        public override void InstallBindings()
        {
            Container.BindInstance(gameStateController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.Bind<ServiceLocator>().AsSingle().NonLazy();
        }
    }
}