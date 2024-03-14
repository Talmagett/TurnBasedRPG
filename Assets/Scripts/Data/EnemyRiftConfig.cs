using Battle;
using Map.Characters;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyRift", menuName = "SO/EnemyRift", order = 1)]
    public class EnemyRiftConfig : ScriptableObject
    {
        public Environment Environment;

        public BaseCharacter[] Enemies;
        //loot
    }
}