using System;
using UnityEngine;

namespace SaveSystem.GameEngine.Objects
{
    [Serializable]
    public struct ResourceData
    {
        [SerializeField] public string id;

        [SerializeField] public int amount;
    }
}