using Map.Characters;
using UnityEngine;
using Zenject;

namespace Map
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacterController playerCharacter;
        [SerializeField] private PartyController partyController;

        public override void InstallBindings()
        {
            Container.BindInstance(playerCharacter).AsSingle();
            Container.BindInstance(partyController).AsSingle();
        }
    }
}