using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private PlayerInput playerInput;

        public override void InstallBindings()
        {
            Container.BindInstance(gameController).AsSingle();
            Container.BindInstance(playerInput).AsSingle();
        }
    }
}