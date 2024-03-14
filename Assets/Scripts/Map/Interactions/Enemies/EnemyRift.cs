using Data;
using Game;
using Map.Characters;
using UnityEngine;
using Zenject;

namespace Map.Interactions.Enemies
{
    public class EnemyRift : MonoBehaviour
    {
        [SerializeField] private EnemyRiftConfig enemyRiftConfig;

        private GameController _gameController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerCharacterController characterController))
                _gameController.EnterBattle(enemyRiftConfig);
        }

        [Inject]
        public void Construct(GameController gameController)
        {
            _gameController = gameController;
        }
    }
}