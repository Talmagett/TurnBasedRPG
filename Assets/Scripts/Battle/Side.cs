using System;
using System.Collections.Generic;
using Actors;
using Battle.Characters;
using Lessons.Game;
using Map.Characters;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class Side
    {
        private const float DeltaPosition = 2;
        private readonly Transform _parent;

        private List<Actor> _units = new();
        public event Action OnUnitsCleared;

        public Side(Transform parent)
        {
            _parent = parent;
        }
        
        public Actor GetRandom()
        {
            var rand = Random.Range(0, _units.Count);
            return _units[rand];
        }
        
        public IEnumerable<Actor> GetAllCharacters()
        {
            return _units;
        }

        public void ClearField()
        {
            _units.Clear();
            while (_parent.childCount > 0) Object.DestroyImmediate(_parent.GetChild(0).gameObject);
        }

        public void SpawnUnits(Actor[] actors, DiContainer container,Owner owner)
        {
            var len = actors.Length;
            var pos = -(len - 1) / 2f * DeltaPosition;
            var eventBus = container.Resolve<EventBus>();
            var battleController = container.Resolve<BattleController>();
            for (var i = 0; i < len; i++)
            {
                var unit = container.InstantiatePrefab(actors[i], _parent).GetComponent<Actor>();
                
                unit.Init(eventBus,battleController,owner);
                unit.transform.SetPositionAndRotation(_parent.position + Vector3.forward * pos, _parent.rotation);
                _units.Add(unit);
                unit.gameObject.SetActive(true);
                pos += DeltaPosition;
            }
        }

        public void DespawnUnit(Actor baseCharacter)
        {
            _units.Remove(baseCharacter);
            baseCharacter.DestroySelf();
        }
    }
}