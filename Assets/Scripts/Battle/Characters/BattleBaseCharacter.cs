using Cysharp.Threading.Tasks;
using Map.Characters;
using UnityEngine;
using Zenject;

namespace Battle.Characters
{
    public abstract class BattleBaseCharacter : MonoBehaviour, IBattleTurn
    {
        protected BaseCharacter Character { get; private set; }
        protected BattleController BattleController;

        private UniTaskCompletionSource<bool> _hasFinished; 
            
        [Inject]
        public void Construct(BattleController battleController)
        {
            BattleController = battleController;
        }

        public void Init(BaseCharacter character)
        {
            Character = GetComponent<BaseCharacter>();
        }

        public abstract UniTask Run();
    }
}