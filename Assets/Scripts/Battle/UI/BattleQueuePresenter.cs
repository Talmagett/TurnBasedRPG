using UnityEngine;
using Zenject;

namespace Battle.UI
{
    public class BattleQueuePresenter : MonoBehaviour
    {
        [SerializeField] private BattleQueueView battleQueueView;
        private const float QueueViewTime=50;
        private BattleController _battleController;
        
        [Inject]
        public void Construct(BattleController battleController)
        {
            _battleController = battleController;
            _battleController.OnNextTurn += UpdateView;
        }

        private void UpdateView()
        {
            battleQueueView.Clear();
            battleQueueView.SetCurrentTurnView(_battleController.BattleQueue.CurrentCharacter.GetConfig().Icon);
            foreach (var unitTimes in _battleController.BattleQueue.GetUnitTimes())
            {
                if (unitTimes.Time > _battleController.BattleQueue.CurrentTime+QueueViewTime)
                    continue;
                var percent = (unitTimes.Time - _battleController.BattleQueue.CurrentTime)/QueueViewTime;
                battleQueueView.SetIcon(unitTimes.Character.GetConfig().Icon,percent);
            }
        }
    }
}