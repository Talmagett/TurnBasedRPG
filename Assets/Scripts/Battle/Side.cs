using System;
using System.Collections.Generic;
using Actors;
using Map.Characters;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class Side
    {
        private const float deltaPosition = 2;
        [field: SerializeField] public Transform Parent { get; private set; }

        private List<BattleActor> _units = new();
        public event Action OnUnitsCleared;

        public BattleActor GetRandom()
        {
            var rand = Random.Range(0, _units.Count);
            return _units[rand];
        }
        
        public IEnumerable<BattleActor> GetAllCharacters()
        {
            return _units;
        }

        public void ClearField()
        {
            _units.Clear();
            while (Parent.childCount > 0) Object.DestroyImmediate(Parent.GetChild(0).gameObject);
        }

        public void SpawnUnits(BattleActor[] enemiesConfig, BattleController battleController)
        {
            var len = enemiesConfig.Length;
            var pos = -(len - 1) / 2f * deltaPosition;
            for (var i = 0; i < len; i++)
            {
                var unit = battleController.SpawnUnit(enemiesConfig[i], Parent);
                //unit.InitStats(enemiesConfig[i].characterConfig.Value.Stats);
                unit.transform.SetPositionAndRotation(Parent.position + Vector3.forward * pos, Parent.rotation);
                _units.Add(unit);
                unit.gameObject.SetActive(true);
                pos += deltaPosition;
            }
        }

        public void DespawnUnit(BattleActor baseCharacter)
        {
            _units.Remove(baseCharacter);
            baseCharacter.DestroySelf();
        }
    }
}