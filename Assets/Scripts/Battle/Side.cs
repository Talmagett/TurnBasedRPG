using System;
using System.Collections.Generic;
using Map.Characters;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Battle
{
    [Serializable]
    public class Side
    {
        private const float deltaPosition = 2;
        [field: SerializeField] public Transform Parent { get; private set; }

        private List<BaseCharacter> _units = new();
        public event Action OnUnitsCleared;

        public IEnumerable<BaseCharacter> GetAllCharacters()
        {
            return _units;
        }

        public void ClearField()
        {
            _units.Clear();
            while (Parent.childCount > 0) Object.DestroyImmediate(Parent.GetChild(0).gameObject);
        }

        public void SpawnUnits(BaseCharacter[] enemiesConfig, BattleController battleController)
        {
            var len = enemiesConfig.Length;
            var pos = -(len - 1) / 2f * deltaPosition;
            for (var i = 0; i < len; i++)
            {
                var unit = battleController.SpawnUnit(enemiesConfig[i], Parent);
                unit.transform.SetPositionAndRotation(Parent.position + Vector3.forward * pos, Parent.rotation);
                _units.Add(unit);
                unit.gameObject.SetActive(true);
                pos += deltaPosition;
            }
        }

        public void DespawnUnit(BaseCharacter baseCharacter)
        {
            _units.Remove(baseCharacter);
            baseCharacter.DestroySelf();
        }
    }
}