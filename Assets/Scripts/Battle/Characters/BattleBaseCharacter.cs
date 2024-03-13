using Map.Characters;
using UnityEngine;
using Zenject;

namespace Battle.Characters
{
    public abstract class BattleBaseCharacter : MonoBehaviour
    {
        [field: SerializeField] public BaseCharacter Character { get; private set; }

        protected BattleController BattleController;
        [Inject]
        public void Construct(BattleController battleController)
        {
            BattleController = battleController;
        }
    }
}