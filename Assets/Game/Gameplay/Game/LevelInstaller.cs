using Game.Gameplay.Battle;
using Game.UI.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Game
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private BattleController battleController;
        [SerializeField] private UIController uiController; // ReSharper disable Unity.PerformanceAnalysis

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BattleContainer>().AsSingle().NonLazy();
            Container.BindInstance(gameStateController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.BindInstance(uiController).AsSingle();
        }
    }
}