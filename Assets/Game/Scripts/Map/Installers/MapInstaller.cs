using Zenject;

namespace Map.Installers
{
    public class MapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MapInput.PlayerMapInput>().AsSingle().NonLazy();
        }
    }
}