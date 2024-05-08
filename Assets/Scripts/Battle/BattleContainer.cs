using System;
using System.Collections.Generic;
using System.Linq;
using Battle.Actors;
using Battle.Actors.Model;
using Configs.Enums;
using JetBrains.Annotations;
using Random=UnityEngine.Random;
namespace Battle
{
    [UsedImplicitly]
    public class BattleContainer
    {
        public event Action<Owner> OnUnitsCleared;
        
        private readonly List<ActorData> _units = new();
        public Owner LastMoved { get; set; }
        
        public void AddUnit(ActorData unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(ActorData unit)
        {
            _units.Remove(unit);
            unit.DestroySelf();
            if(_units.Count(t=>t.Get<Ownership>(AtomicAPI.Owner)==unit.Get<Ownership>(AtomicAPI.Owner))==0)
                OnUnitsCleared?.Invoke(unit.Get<Ownership>(AtomicAPI.Owner).Owner);
        }
        
        public ActorData GetRandomEnemy(ActorData actorData)
        {
            if (!actorData.TryGet(AtomicAPI.Owner, out Ownership owner))
                throw new NullReferenceException($"No ownership component is {actorData.Get(AtomicAPI.Name)}");
            
            var enemies = _units.Where(t => t.Get<Ownership>(AtomicAPI.Owner) != owner).ToArray();
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand];
        }
        
        public ActorData GetRandomAlly(ActorData actorData)
        {
            if (!actorData.TryGet(AtomicAPI.Owner, out Ownership owner))
                throw new NullReferenceException($"No ownership component is {actorData.Get(AtomicAPI.Name)}");

            var enemies = _units.Where(t => t.Get<Ownership>(AtomicAPI.Owner) == owner).ToArray();
            var rand = Random.Range(0, enemies.Length);
            return enemies[rand];
        }
        
        public IEnumerable<ActorData> GetAllCharacters()
        {
            return _units;
        }

        public void ClearField()
        {
            _units.Clear();
        }
    }
}