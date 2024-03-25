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
        [SerializeField] private CharacterConfig[] playerParty;

        public override void InstallBindings()
        {
            Container.BindInstance(gameController).AsSingle();
            Container.BindInstance(battleController).AsSingle();
            Container.Bind<Party>().AsSingle().WithArguments(playerParty).NonLazy();
            Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
        }
    }
}