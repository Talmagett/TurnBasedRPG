using Data;
using Game;
using UnityEngine;
using Zenject;

namespace Map.Characters.Interactions.Enemies
{
    public class EnemyRift : MonoBehaviour
    {
        [SerializeField] private EnemyRiftConfig enemyRiftConfig;

        private GameController _gameController;
        
        [Inject]
        public void Construct(GameController gameController)
        {
            _gameController = gameController;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerCharacterController characterController))
            {
                _gameController.EnterBattle(enemyRiftConfig);
            }
        }
    }
}