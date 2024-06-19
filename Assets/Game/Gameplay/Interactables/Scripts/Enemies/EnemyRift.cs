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
            if (!other.TryGetComponent(out PlayerCharacterController characterController))
                return;
            _gameStateController.EnterBattle(enemyRiftConfig);
            gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }
    }
}