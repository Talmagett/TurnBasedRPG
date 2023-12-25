using System;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Battle.Core
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private bool shuffle;

        private List<BattleUnit> _units = new();
        private readonly List<BattleUnit> _movingUnits = new();

        private BattleUnit _currentMovingUnit;

        //-----------
        // on battle Finish give loot

        private readonly Random _randomizer = new();

        private void Awake()
        {
            _units = GetComponentsInChildren<BattleUnit>().ToList();
        }

        private void Start()
        {
            AddUnits();
        }

        private void Update()
        {
            ProcessTurn();
        }

        private void AddUnits()
        {
            _currentMovingUnit = null;
            _units.ToList().RemoveAll(t => t == null);
            if (shuffle)
                _randomizer.Shuffle(_units.ToArray());

            foreach (var item in _units)
            {
                if (item == null)
                    continue;
                item.Init();
                _movingUnits.Add(item);
            }
        }

        private void ProcessTurn()
        {
            if(_currentMovingUnit==null)
                ChangeTurn();
            if (_currentMovingUnit.IsMoving == false)
            {
                _movingUnits.RemoveAt(0);
                ChangeTurn();
            }
        }

        private void ChangeTurn()
        {
            if (_movingUnits.Any())
            {
                _currentMovingUnit = _movingUnits[0];
                if (_currentMovingUnit != null) 
                    _currentMovingUnit.StartTurn();
            }
            else
            {
                AddUnits();
            }
        }
    }
}