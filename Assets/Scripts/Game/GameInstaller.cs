using Battle;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private BattleController battleController;

        public override void InstallBindings()
        {
            Container.BindInstance(gameController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
        }
    }
}