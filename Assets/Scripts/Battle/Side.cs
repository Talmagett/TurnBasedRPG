using System;
using System.Collections.Generic;
using Battle.Actors;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class Side
    {
        public event Action OnUnitsCleared;
        
        private const float DeltaPosition = 2;
        private readonly Transform _parent;

        private List<ActorData> _units = new();

        public Side(Transform parent)
        {
            _parent = parent;
        }


        public ActorData GetRandom()
        {
            var rand = Random.Range(0, _units.Count);
            return _units[rand];
        }

        public IEnumerable<ActorData> GetAllCharacters()
        {
            return _units;
        }

        public void ClearField()
        {
            _units.Clear();
            while (_parent.childCount > 0) Object.DestroyImmediate(_parent.GetChild(0).gameObject);
        }

        public ActorData SetupUnit(ActorData unit, float position)
        {
            unit.transform.SetParent(_parent);
            unit.transform.SetPositionAndRotation(_parent.position + Vector3.forward * position*DeltaPosition, _parent.rotation);
            _units.Add(unit);
            return unit;
        }

        public void DespawnUnit(ActorData baseCharacter)
        {
            _units.Remove(baseCharacter);
            baseCharacter.DestroySelf();
            if(_units.Count==0)
                OnUnitsCleared?.Invoke();
        }
    }
}