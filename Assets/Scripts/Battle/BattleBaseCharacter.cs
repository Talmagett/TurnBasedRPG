using Data;
using UnityEngine;

namespace Battle
{
    public abstract class BattleBaseCharacter : MonoBehaviour
    {
        [field: SerializeField] public CharacterConfig Config { get; private set; }
    }
}