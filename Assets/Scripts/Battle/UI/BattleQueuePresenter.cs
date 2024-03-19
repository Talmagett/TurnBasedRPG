using UnityEngine;
using Zenject;

namespace Battle.UI
{
    public class BattleQueuePresenter : MonoBehaviour
    {
        [SerializeField] private BattleQueueView battleQueueView;

        private BattleController _battleController;

        private void OnEnable()
        {
            if (_battleController.BattleQueue != null)
                _battleController.BattleQueue.OnQueueChanged += UpdateView;
        }

        private void OnDisable()
        {
            battleQueueView.Clear();
            if (_battleController.BattleQueue != null)
                _battleController.BattleQueue.OnQueueChanged -= UpdateView;
        }

        [Inject]
        public void Construct(BattleController battleController)
        {
            _battleController = battleController;
        }

        private void UpdateView()
        {
            battleQueueView.Clear();
            battleQueueView.SetCurrentTurnView(_battleController.BattleQueue.CurrentCharacter.characterConfig.Value.Icon);
            foreach (var unitTimes in _battleController.BattleQueue.GetUnitTimes())
            {
                if (unitTimes.time > _battleController.BattleQueue.CurrentTime + BattleQueue.QueueTime)
                    continue;
                var percent = (unitTimes.time - _battleController.BattleQueue.CurrentTime) / BattleQueue.QueueTime;
                battleQueueView.SpawnIcon(unitTimes.character.characterConfig.Value.Icon, percent);
            }
        }
    }
}