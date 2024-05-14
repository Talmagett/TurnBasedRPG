using System;
using UnityEngine;

namespace Game.App.SaveSystem.GameEngine.Objects
{
    [Serializable]
    public struct UnitData
    {
        [SerializeField] public string type;

        [SerializeField] public int hitPoints;

        [SerializeField] public string position;

        [SerializeField] public string rotation;
    }
}