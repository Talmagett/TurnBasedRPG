using System;
using System.Collections.Generic;
using System.Linq;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Characters.Scripts.Keys;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay.Battle
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
        }

        public bool CheckForFinish()
        {
            var units = _units.GroupBy(t => t.Get<Component_Owner>().owner.Value).ToArray();
            Debug.Log(units.Length+"units"+units.FirstOrDefault().Key);
            if (units.Length != 1) return false;
            
            OnUnitsCleared?.Invoke(units.FirstOrDefault()!.Key);
            return true;
        }
        
        public IEntity GetRandomEnemy(IEntity characterEntity)
        {
            var owner = characterEntity.Get<Component_Owner>();
            var enemies = _units.Where(t=>t.Get<Component_Life>().health.Value>0).Where(t => t.Get<Component_Owner>().owner.Value != owner.owner.Value).ToArray();
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand];
        }

        public IEntity GetRandomAlly(IEntity characterEntity)
        {
            var owner = characterEntity.Get<Component_Owner>();
            var enemies = _units.Where(t=>t.Get<Component_Life>().health.Value>0).Where(t => t.Get<Component_Owner>().owner.Value == owner.owner.Value).ToArray();
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand];
        }

        public IEntity[] GetAllCharacters()
        {
            return _units.ToArray();
        }
        
        public IEntity GetRandomCharacter()
        {
            var rand = Random.Range(0, _units.Count);
            return _units[rand];
        }

        public IEntity[] GetAllEnemies(IEntity characterEntity)
        {
            var owner = characterEntity.Get<Component_Owner>();
            var enemies = _units.Where(t => t.Get<Component_Owner>().owner.Value != owner.owner.Value).ToArray();
            return enemies;
        }
        
        
        public IEntity[] GetAllAllies(IEntity characterEntity)
        {
            var owner = characterEntity.Get<Component_Owner>();
            var enemies = _units.Where(t => t.Get<Component_Owner>().owner.Value == owner.owner.Value).ToArray();
            return enemies;
        }
        
        public void ClearField()
        {
            _units.Clear();
        }
    }
}