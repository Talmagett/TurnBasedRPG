using Configs;
using Configs.Character;
using Game.Heroes;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterConfig[] heroesConfigs;
    [SerializeField] private AbilitiesStorage abilitiesStorage;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
        Container.Bind<HeroParty>().AsSingle().WithArguments(heroesConfigs);
        Container.BindInstance(abilitiesStorage).AsSingle();
    }
}