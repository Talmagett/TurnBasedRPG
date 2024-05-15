using Game.App.SaveSystem.GameEngine.Systems;
using Game.App.SaveSystem.SaveSystem;
using Game.Gameplay.Characters.Scripts.SO;
using Game.Gameplay.Game.Heroes;
using Game.Meta.Inventory.Inventory;
using Game.Meta.Items.Scripts.ItemModule;
using UnityEngine;
using Zenject;

namespace Game.App.Loading
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private HeroCharacterConfig[] heroesConfigs;
        [SerializeField] private ItemsContainer itemContainer;
        [SerializeField] private ItemConfig[] defaultItems;
        [SerializeReference] private ISaveLoader[] saveLoaders;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<GameRepository>().AsSingle().NonLazy();
            Container.BindInstance(saveLoaders).AsSingle();
            Container.Bind<Inventory>().AsSingle().NonLazy();
            Container.BindInstance(itemContainer).AsSingle()
                .OnInstantiated<ItemsContainer>((ctx, t) => t.Initialize())
                .NonLazy();
            Container.Bind<ItemsManager>().AsSingle().WithArguments(defaultItems).NonLazy();
            Container.Bind<GameContext>().AsSingle().NonLazy();
            Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
            Container.Bind<HeroParty>().AsSingle().WithArguments(heroesConfigs);
            Container.Bind<SaveLoadManager>().AsSingle().OnInstantiated<SaveLoadManager>((ctx, s) => s.Load());
        }
    }
}