using Game.App.SaveSystem.SaveSystem;
using Game.Gameplay.Battle;
using Game.Gameplay.Game.Control;
using Game.UI.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private BattleController battleController;
        [SerializeField] private UIController uiController;
        [SerializeField] private CursorController cursorController;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BattleContainer>().AsSingle().NonLazy();
            Container.BindInstance(gameStateController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.BindInstance(uiController).AsSingle();
            Container.BindInstance(cursorController).AsSingle().OnInstantiated<CursorController>((ctx, t) => t.SetCursor(CursorType.None));;
        }
    }
}