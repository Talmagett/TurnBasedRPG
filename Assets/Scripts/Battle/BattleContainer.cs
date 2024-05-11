using System;
using System.Collections.Generic;
using System.Linq;
using Battle.Actors;
using Battle.Actors.Model;
using Character.Components;
using Configs.Enums;
using Entities;
using JetBrains.Annotations;
using Random=UnityEngine.Random;
namespace Battle
{
    [UsedImplicitly]
    public class BattleContainer
    {
        public event Action<Owner> OnUnitsCleared;
        
        private readonly List<IEntity> _units = new();
        public Owner LastMoved { get; set; }
        
        public void AddUnit(IEntity unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(IEntity unit)
        {
            _units.Remove(unit);
            if(_units.Count(t=>t.Get<Component_Owner>()==unit.Get<Component_Owner>())==0)
                OnUnitsCleared?.Invoke(unit.Get<Component_Owner>().owner.Value);
        }
        
        public IEntity GetRandomEnemy(IEntity characterEntity)
        {
            if (!characterEntity.TryGet(out Component_Owner owner))
                throw new NullReferenceException($"No ownership component is {characterEntity.Get<Component_ID>()}");
            
            var enemies = _units.Where(t => t.Get<Component_Owner>().owner != owner.owner).ToArray();
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand];
        }
        
        public IEntity GetRandomAlly(IEntity characterEntity)
        {
            if (!characterEntity.TryGet(out Component_Owner owner))
                throw new NullReferenceException($"No ownership component is {characterEntity.Get<Component_ID>()}");

            var enemies = _units.Where(t => t.Get<Component_Owner>().owner != owner.owner).ToArray();
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