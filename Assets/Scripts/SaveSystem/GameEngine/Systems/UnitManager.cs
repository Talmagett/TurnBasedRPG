using System;
using System.Collections.Generic;
using System.Linq;
using SaveSystem.GameEngine.Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SaveSystem.GameEngine.Systems
{
    //Нельзя менять!
    [Serializable]
    public sealed class UnitManager
    {
        [SerializeField]
        private Transform container;

        [ShowInInspector, ReadOnly]
        private HashSet<Unit> sceneUnits = new();

        [SerializeField] private List<Unit> unitsPrefab=new ();

        public UnitManager()
        {
        }

        public UnitManager(Transform container)
        {
            this.container = container;
        }
        
        public void SetupUnits(IEnumerable<Unit> units)
        {
            this.sceneUnits = new HashSet<Unit>(units);
        }

        public void SetContainer(Transform container)
        {
            this.container = container;
        }

        [Button]
        public Unit SpawnUnit(Unit prefab, Vector3 position, Quaternion rotation)
        {
            var unit = Object.Instantiate(prefab, position, rotation, this.container);
            this.sceneUnits.Add(unit);
            return unit;
        }

        [Button]
        public void DestroyUnit(Unit unit)
        {
            if (this.sceneUnits.Remove(unit))
            {
                Object.Destroy(unit.gameObject);
            }
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return this.sceneUnits;
        }
        
        public Unit GetUnitPrefab(string type)
        {
            if (!unitsPrefab.Any(t=>t.name==type))
                throw new NullReferenceException($"No such type of Unit - {type}");
            return unitsPrefab.FirstOrDefault(t => t.name == type);
        }
    }
}