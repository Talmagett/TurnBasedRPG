using Configs;
using Game.Heroes;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterConfig[] heroesConfigs;

    public override void InstallBindings()
    {
        Container.Bind<PlayerInputActions>().AsSingle().NonLazy();
        Container.Bind<HeroParty>().AsSingle().WithArguments(heroesConfigs);
    }
}