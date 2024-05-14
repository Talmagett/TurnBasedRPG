using Game.App.SaveSystem.GameEngine.Systems;
using Game.App.SaveSystem.SaveSystem;
using Game.Configs.Configs.Character;
using Game.Gameplay.Game.Control;
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
        [SerializeField] private ItemConfig[] allItems;
        [SerializeField] private ItemConfig[] defaultItems;
        [SerializeReference] private ISaveLoader[] saveLoaders;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<GameRepository>().AsSingle().NonLazy();
            Container.BindInstance(saveLoaders).AsSingle();
            Container.Bind<Inventory>().AsSingle().NonLazy();
            Container.Bind<ItemsManager>().AsSingle().WithArguments(defaultItems)
                .OnInstantiated<ItemsManager>((ctx,i)=>i.InitializeAllItems(allItems)).NonLazy();
            Container.Bind<GameContext>().AsSingle().NonLazy();
            Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
            Container.Bind<HeroParty>().AsSingle().WithArguments(heroesConfigs);
            Container.Bind<SaveLoadManager>().AsSingle().OnInstantiated<SaveLoadManager>((ctx, s) => s.Load());
        }
    }
}