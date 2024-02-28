using Game.Map.Scripts;
using Zenject;

namespace Map.Installers
{
    public class MapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerMapInput>().AsSingle().NonLazy();
        }
    }
}