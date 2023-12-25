using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;
using Random = System.Random;

namespace Battle.Core
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private bool shuffle;

        public List<BattleUnit> Units {get;private set;}
        
        public BattleUnit[] PlayerUnits => Units.Where(t => t.IsPlayer()).ToArray();
        private readonly List<BattleUnit> _movingUnits = new();

        private BattleUnit _currentMovingUnit;

        //-----------
        // on battle Finish give loot

        private readonly Random _randomizer = new();

        private void Awake()
        {
            Units = GetComponentsInChildren<BattleUnit>().ToList();
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
            Units.ToList().RemoveAll(t => t == null);
            if (shuffle)
                _randomizer.Shuffle(Units.ToArray());

            foreach (var item in Units)
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