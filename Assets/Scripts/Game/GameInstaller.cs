using Actors;
using Battle;
using Battle.Characters;
using Data;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private BattleController battleController;
        [SerializeField] private ParticleStorage particleStorage;
        
        public override void InstallBindings()
        {
            Container.BindInstance(gameController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.BindInstance(particleStorage).AsSingle();
            Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
        }
    }
}