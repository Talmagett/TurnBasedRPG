using System.Collections.Generic;
using Sample;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var stats = new KeyValuePair<string, int>[]
        {
            new("damage", 10),
            new("health", 10),
            new("speed", 10)
        };
        Container.Bind<Character>().AsSingle().WithArguments(stats).NonLazy();

        Container.Bind<Inventory>().AsSingle().NonLazy();
        Container.Bind<Equipment>().AsSingle().NonLazy();
        Container.Bind<EquipmentEffector>().AsSingle().NonLazy();
    }
}