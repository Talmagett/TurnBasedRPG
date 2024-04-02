using System.Collections.Generic;
using Battle;
using UnityEngine;
using Zenject;

namespace Visual.UI.Battle
{
    public class BattleQueuePresenter : MonoBehaviour
    {
        [SerializeField] private BattleQueueView battleQueueViewPrefab;
        [SerializeField] private RectTransform parent;

        private BattleController _battleController;
        private UnitTime[] _unitTimes;
        private float maxX;
        private float minX;

        [Inject]
        public void Construct(BattleController battleController)
        {
            _battleController = battleController;
        }

        private void Awake()
        {
            var corners = new Vector3[4];
            parent.GetLocalCorners(corners);
            minX = corners[0].x;
            maxX = corners[2].x;
        }
        /*
        public CharacterIconView SpawnIcon(Sprite icon, float percent)
        {
            var xPos = (maxX - minX) * percent;
            var position = parent.position;
            var characterIconView =
                Instantiate(iconViewPrefab, new Vector2(position.x + minX + xPos, position.y), Quaternion.identity,
                    parent);
            characterIconView.SetIcon(icon);
            characterIconView.transform.SetAsFirstSibling();
            return characterIconView;
        }*/
        
        private void OnEnable()
        {
            _battleController.BattleQueue.OnQueueChanged += UpdateView;
        }

        private void OnDisable()
        {
            _battleController.BattleQueue.OnQueueChanged -= UpdateView;
        }

        private void UpdateView()
        {
            _unitTimes = _battleController.BattleQueue.GetUnitTimes();
            
            /* TODO: view
            if (_battleController.BattleQueue.CurrentCharacter != null)
            {
                battleQueueViewPrefab.SetIcon(_battleController.BattleQueue.CurrentCharacter.ActorData.Icon);
                print(_battleController.BattleQueue.CurrentCharacter.ActorData.ID);
            }
            foreach (var unitTimes in _unitTimes)
            {
                if (unitTimes.time >
                    _battleController.BattleQueue.CurrentTime + _battleController.BattleQueue.QueueTime)
                    continue;
                var percent = (unitTimes.time - _battleController.BattleQueue.CurrentTime) /
                              _battleController.BattleQueue.QueueTime;
                battleQueueViewPrefab.SpawnIcon(unitTimes.character.ActorData.Icon, percent);
            }*/
        }
    }
}