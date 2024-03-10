using System.Collections.Generic;
using Data;
using Map.Characters;
using UnityEngine;

namespace Battle
{
    [System.Serializable]
    public class Side
    {
        [field: SerializeField] public Transform Parent { get; private set; }

        public IEnumerable<BaseCharacter> GetAllCharacters() => _units;
        
        private List<BaseCharacter> _units=new List<BaseCharacter>();

        public void ClearField()
        {
            while (Parent.childCount > 0)
            {
                Object.DestroyImmediate(Parent.GetChild(0).gameObject);
            }
        }
        
        public void SpawnUnits(BaseCharacter[] enemiesConfig)
        {
            var len = enemiesConfig.Length;
            var deltaPos = 2;
            var minPos = len - 1;
            var index = 0;
            for (float pos = -minPos; pos <= minPos; pos+=deltaPos)
            {
                var unit = Object.Instantiate(enemiesConfig[index], Parent.position+Vector3.forward*pos,Parent.rotation,Parent);
                _units.Add(unit);
                unit.gameObject.SetActive(true);
                index++;
            }
        }
    }
}