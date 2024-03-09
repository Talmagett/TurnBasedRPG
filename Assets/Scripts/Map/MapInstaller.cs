using Map.Characters;
using UnityEngine;
using Zenject;

namespace Map
{
    public class MapInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacterController playerCharacter;
        
        public override void InstallBindings()
        {
            Container.BindInstance(playerCharacter).AsSingle();
        }
    }
}