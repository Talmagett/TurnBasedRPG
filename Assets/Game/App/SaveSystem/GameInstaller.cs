using Game.App.SaveSystem.GameEngine.Objects;
using Game.App.SaveSystem.GameEngine.Systems;
using Game.App.SaveSystem.SaveSystem;
using UnityEngine;
using Zenject;

namespace Game.App.SaveSystem
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private UnitManager unitManager;
        [SerializeField] private ResourceService resourceService;

        public override void InstallBindings()
        {
            Container.Bind<GameContext>().AsSingle().WithArguments(unitManager, resourceService).NonLazy();
            Container.Bind<SaveLoadManager>().AsSingle().NonLazy();

            unitManager.SetupUnits(FindObjectsOfType<Unit>());
            resourceService.SetResources(FindObjectsOfType<Resource>());
        }
    }
}