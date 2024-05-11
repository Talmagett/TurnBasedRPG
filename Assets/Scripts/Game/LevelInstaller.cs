using Battle;
using UI.Views;
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

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BattleContainer>().AsSingle().NonLazy();
            Container.BindInstance(gameStateController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.BindInstance(uiController).AsSingle();
        }
    }
}