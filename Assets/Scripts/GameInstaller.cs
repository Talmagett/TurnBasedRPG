using Configs.Character;
using Game.Control;
using Game.Heroes;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterConfig[] heroesConfigs;
    [SerializeField] private AbilitiesStorage abilitiesStorage;
    [SerializeField] private CursorController cursorController;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
        Container.Bind<HeroParty>().AsSingle().WithArguments(heroesConfigs);
        Container.BindInstance(abilitiesStorage).AsSingle();
        Container.BindInstance(cursorController).AsSingle();
        cursorController.SetCursor(CursorType.None);
    }
}