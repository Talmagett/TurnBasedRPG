using System;
using System.Collections.Generic;
using System.Linq;
using Character.Components;
using Configs.Enums;
using JetBrains.Annotations;
using Modules.Entities.Scripts;
using Random = UnityEngine.Random;

namespace Battle
{
    [UsedImplicitly]
    public class BattleContainer
    {
        private readonly List<IEntity> _units = new();
        public Owner LastMoved { get; set; }
        public event Action<Owner> OnUnitsCleared;

        public void AddUnit(IEntity unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(IEntity unit)
        {
            _units.Remove(unit);
            if (_units.Count(t => t.Get<Component_Owner>().owner.Value == unit.Get<Component_Owner>().owner.Value) == 0)
                OnUnitsCleared?.Invoke(unit.Get<Component_Owner>().owner.Value);
        }

        public IEntity GetRandomEnemy(IEntity characterEntity)
        {
            var owner = characterEntity.Get<Component_Owner>();
            var enemies = _units.Where(t => t.Get<Component_Owner>().owner.Value != owner.owner.Value).ToArray();
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand];
        }

        public IEntity GetRandomAlly(IEntity characterEntity)
        {
            var owner = characterEntity.Get<Component_Owner>();
            var enemies = _units.Where(t => t.Get<Component_Owner>().owner.Value != owner.owner.Value).ToArray();
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand];
        }

        public IEnumerable<IEntity> GetAllCharacters()
        {
            return _units;
        }

        public void ClearField()
        {
            _units.Clear();
        }
    }
}