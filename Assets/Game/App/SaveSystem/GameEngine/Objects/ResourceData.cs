using System;
using UnityEngine;

namespace Game.App.SaveSystem.GameEngine.Objects
{
    [Serializable]
    public struct ResourceData
    {
        [SerializeField] public string id;

        [SerializeField] public int amount;
    }
}