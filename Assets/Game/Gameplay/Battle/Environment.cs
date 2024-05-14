using UnityEngine;

namespace Game.Gameplay.Battle
{
    public class Environment : MonoBehaviour
    {
        [field: SerializeField] public Transform PlayerSpawnPosition { get; private set; }
        [field: SerializeField] public Transform EnemySpawnPosition { get; private set; }
    }
}