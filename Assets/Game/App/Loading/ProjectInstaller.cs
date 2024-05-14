using Game.App.SaveSystem.SaveSystem;
using Game.Configs.Configs.Character;
using Game.Gameplay.Game.Control;
using Game.Gameplay.Game.Heroes;
using Game.Meta.Inventory.Inventory;
using UnityEngine;
using Zenject;

namespace Game.App.Loading
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private HeroCharacterConfig[] heroesConfigs;
        [SerializeField] private PlayerInitData playerInitData;
        [SerializeField] private CursorController cursorController;
        [SerializeReference] private ISaveLoader[] saveLoaders;

        //TODO: load from saves
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            /*
            Container.Bind<GameRepository>().AsSingle().NonLazy();
            Container.BindInstance(saveLoaders).AsSingle();
            */
            Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
            Container.Bind<HeroParty>().AsSingle().WithArguments(heroesConfigs);
            //Container.BindInstance(playerInitData).AsSingle();
            Container.BindInstance(cursorController).AsSingle();
            Container.Bind<Inventory>().AsSingle().WithArguments(playerInitData.GetItems()).NonLazy();

            cursorController.SetCursor(CursorType.None);
        }
    }
}