using Zenject;

namespace Map.Characters
{
    public class MapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerMapInput>().AsSingle().NonLazy();
        }
    }
}