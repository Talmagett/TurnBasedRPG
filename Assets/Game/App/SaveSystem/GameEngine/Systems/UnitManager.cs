using System;
using System.Collections.Generic;
using System.Linq;
using Game.App.SaveSystem.GameEngine.Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.App.SaveSystem.GameEngine.Systems
{
    //Нельзя менять!
    [Serializable]
    public sealed class UnitManager
    {
        [SerializeField] private Transform container;

        [SerializeField] private List<Unit> unitsPrefab = new();

        [ShowInInspector] [ReadOnly] private HashSet<Unit> sceneUnits = new();

        public UnitManager()
        {
        }

        public UnitManager(Transform container)
        {
            this.container = container;
        }

        public void SetupUnits(IEnumerable<Unit> units)
        {
            sceneUnits = new HashSet<Unit>(units);
        }

        public void SetContainer(Transform container)
        {
            this.container = container;
        }

        [Button]
        public Unit SpawnUnit(Unit prefab, Vector3 position, Quaternion rotation)
        {
            var unit = Object.Instantiate(prefab, position, rotation, container);
            sceneUnits.Add(unit);
            return unit;
        }

        [Button]
        public void DestroyUnit(Unit unit)
        {
            if (sceneUnits.Remove(unit)) Object.Destroy(unit.gameObject);
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return sceneUnits;
        }

        public Unit GetUnitPrefab(string type)
        {
            if (!unitsPrefab.Any(t => t.name == type))
                throw new NullReferenceException($"No such type of Unit - {type}");
            return unitsPrefab.FirstOrDefault(t => t.name == type);
        }
    }
}