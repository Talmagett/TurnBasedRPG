using Configs;
using Game;
using UnityEngine;
using Zenject;

namespace Map.Interactions.Enemies
{
    public class EnemyRift : MonoBehaviour
    {
        [SerializeField] private EnemyRiftConfig enemyRiftConfig;

        private GameStateController _gameStateController;

        [Inject]
        public void Construct(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerCharacterController characterController))
                _gameStateController.EnterBattle(enemyRiftConfig);
        }
    }
}