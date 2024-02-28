using MapInput;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Map
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float speed;

        private PlayerMapInput _playerMapInput;

        [Inject]
        public void Construct(PlayerMapInput playerMapInput)
        {
            _playerMapInput = playerMapInput;
        }

        private void Update()
        {
            agent.Move(_playerMapInput.MoveDir * speed * Time.deltaTime);
        }
    }
}