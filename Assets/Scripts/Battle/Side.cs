using System;
using System.Collections.Generic;
using Data;
using Map.Characters;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Battle
{
    [System.Serializable]
    public class Side
    {
        [field: SerializeField] public Transform Parent { get; private set; }
        private const float deltaPosition=2;
        public event Action OnUnitsCleared; 
        public IEnumerable<BaseCharacter> GetAllCharacters() => _units;
        
        private List<BaseCharacter> _units=new List<BaseCharacter>();

        public void ClearField()
        {
            _units.Clear();
            while (Parent.childCount > 0)
            {
                Object.DestroyImmediate(Parent.GetChild(0).gameObject);
            }
        }
        
        public void SpawnUnits(BaseCharacter[] enemiesConfig)
        {
            var len = enemiesConfig.Length;
            var pos = -(len - 1)/2f*deltaPosition;
            for (var i = 0; i < len; i++)
            {
                var unit = Object.Instantiate(enemiesConfig[i], Parent.position+Vector3.forward*pos,Parent.rotation,Parent);
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