using Game.Gameplay.Environment.Scripts;
using Game.Gameplay.Game;
using Game.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Interactables.Scripts.Enemies
{
    public class EnemyRift : MonoBehaviour
    {
        [SerializeField] private EnemyRiftConfig enemyRiftConfig;

        private GameStateController _gameStateController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerCharacterController characterController))
                _gameStateController.EnterBattle(enemyRiftConfig);
        }

        [Inject]
        public void Construct(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }
    }
}