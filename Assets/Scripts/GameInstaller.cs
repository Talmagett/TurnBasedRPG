using Configs.Character;
using Game.Control;
using Game.Heroes;
using Modules.Items.Scripts.Inventory;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterConfig[] heroesConfigs;
    [SerializeField] private AbilitiesStorage abilitiesStorage;
    [SerializeField] private CursorController cursorController;

    //TODO: load from saves
    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
        Container.Bind<HeroParty>().AsSingle().WithArguments(heroesConfigs);
        Container.BindInstance(abilitiesStorage).AsSingle();
        Container.BindInstance(cursorController).AsSingle();

        //Container.Bind<Character>().AsSingle().WithArguments(stats).NonLazy();

        Container.Bind<Inventory>().AsSingle().NonLazy();
        /*Container.Bind<Equipment.Equipment>().AsSingle().NonLazy();
        Container.Bind<EquipmentEffector>().AsSingle().NonLazy();*/

        cursorController.SetCursor(CursorType.None);
    }
}