using System.Collections.Generic;
using System.Linq;
using Game.App.SaveSystem.GameEngine.Objects;
using Game.App.SaveSystem.GameEngine.Systems;
using Game.App.SaveSystem.SaveSystem;
using UnityEngine;

namespace Game.App.SaveSystem.SaveLoaders
{
    public class UnitSaveLoader : SaveLoader<UnitData[], UnitManager>
    {
        protected override void SetupData(UnitManager unitManager, UnitData[] loadedUnitsDataArray)
        {
            var unitsOnLevel = unitManager.GetAllUnits().ToList();
            var loadedUnitsData = loadedUnitsDataArray.ToList();

            var result = new List<(Unit, UnitData)>();
            for (var i = loadedUnitsData.Count - 1; i >= 0; i--)
            for (var j = unitsOnLevel.Count - 1; j >= 0; j--)
            {
                if (loadedUnitsData[i].type != unitsOnLevel[j].Type) continue;

                result.Add((unitsOnLevel[j], loadedUnitsData[i]));
                loadedUnitsData.RemoveAt(i);
                unitsOnLevel.RemoveAt(j);
                break;
            }

            foreach (var unitPair in result.ToList()) unitPair.Item1.HitPoints = unitPair.Item2.hitPoints;
            //----Unit нельзя менять, а так тут должно быть это ) 
            //unitPair.levelUnit.Position = unitPair.loadedUnit.position;
            //unitPair.levelUnit.Rotation = unitPair.loadedUnit.rotation;
            for (var i = unitsOnLevel.Count - 1; i >= 0; i--) unitManager.DestroyUnit(unitsOnLevel[i]);

            foreach (var unitData in loadedUnitsData)
            {
                var unitPrefab = unitManager.GetUnitPrefab(unitData.type);

                var position = JsonUtility.FromJson<Vector3>(unitData.position);
                var rotation = JsonUtility.FromJson<Vector3>(unitData.rotation);

                var spawnedUnit = unitManager.SpawnUnit(unitPrefab, position, Quaternion.Euler(rotation));
                spawnedUnit.HitPoints = unitData.hitPoints;
            }

            Debug.Log("units were loaded");
        }

        protected override UnitData[] ConvertToData(UnitManager unitManager)
        {
            var units = unitManager.GetAllUnits().ToArray();
            Debug.Log($"<color=green>{units.Length} units was saved</color>");
            var unitsData = new UnitData[units.Length];
            for (var i = 0; i < units.Length; i++)
            {
                unitsData[i].type = units[i].Type;
                unitsData[i].hitPoints = units[i].HitPoints;
                unitsData[i].position = JsonUtility.ToJson(units[i].Position);
                unitsData[i].rotation = JsonUtility.ToJson(units[i].Rotation);
            }

            return unitsData;
        }
    }
}