using SaveSystem.GameEngine.Objects;
using SaveSystem.GameEngine.Systems;
using SaveSystem.SaveSystem;
using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private UnitManager unitManager;
        [SerializeField] private ResourceService resourceService;
        public override void InstallBindings()
        {
            Container.Bind<GameContext>().AsSingle().WithArguments(unitManager,resourceService).NonLazy();
            Container.Bind<SaveLoadManager>().AsSingle().NonLazy();
        
            unitManager.SetupUnits(FindObjectsOfType<Unit>());
            resourceService.SetResources(FindObjectsOfType<Resource>());
        }
    }
}