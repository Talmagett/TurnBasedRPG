using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Elements;
using Battle.Characters;
using Configs.Enums;
using Sirenix.OdinInspector;

namespace Battle
{
    [Serializable]
    public class BattleQueue
    {
        public BattleActor CurrentCharacter { get; private set; }
        
        [ReadOnly] [ShowInInspector] private readonly List<BattleActor> _unitList = new();
        private readonly BattleController _battleController;
        private int _currentTime;

        public event Action OnQueueChanged;
        public event Action<int> OnTimeChanged;
        public event Action<BattleActor> OnCharacterChanged;

        public BattleQueue(BattleController battleController)
        {
            _battleController = battleController;
        }

        public void Clear()
        {
            CurrentCharacter = null;
            _currentTime = 0;
            _unitList.Clear();
        }

        public void AddUnits(IEnumerable<BattleActor> units)
        {
            foreach (var unit in units)
                AddUnit(unit);

            OnQueueChanged?.Invoke();
        }

        public void AddUnit(BattleActor unit)
        {
            _unitList.Add(unit);
        }

        public void RemoveUnit(BattleActor unit)
        {
            _unitList.Remove(unit);
            OnQueueChanged?.Invoke();
        }

        public void NextTime()
        {
            _currentTime++;
            OnTimeChanged?.Invoke(_currentTime);

            _unitList.ForEach(t =>
            {
                if (!t.ActorData.TryGet(AtomicPropertyAPI.CooldownKey, out AtomicVariable<int> cooldown)) return;
                cooldown.Value--;
            });
            _battleController.NextTurn();
        }

        public void NextTurn()
        {
            var movingUnits = _unitList.Where(t =>
            {
                if (!t.ActorData.TryGet(AtomicPropertyAPI.CooldownKey, out AtomicVariable<int> cooldown)) return false;

                return cooldown.Value <= 0;
            }).ToList();

            if (!movingUnits.Any())
            {
                NextTime();
                return;
            }

            CurrentCharacter = movingUnits[0];
            CurrentCharacter.ActorData.Select();
            CurrentCharacter.Run();
            OnCharacterChanged?.Invoke(CurrentCharacter);
        }
    }
}