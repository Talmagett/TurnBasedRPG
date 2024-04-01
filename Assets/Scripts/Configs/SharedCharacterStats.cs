using System;
using System.Collections.Generic;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class SharedCharacterStats
    {
        [ReadOnly][SerializeField] private bool check;
        private Dictionary<StatKey, float> _stats;

        public SharedCharacterStats(Dictionary<StatKey, float> values)
        {
            _stats = values;
        }

        public Dictionary<StatKey, float> GetAllStats()
        {
            Dictionary<StatKey, float> stats = new();
            foreach (var (key,value) in _stats)
            {
                stats.Add(key,value);
            }
            return stats;
        }
        
        public float GetStat(StatKey key)
        {
            return _stats[key];
        }

        public void SetStat(StatKey key, float newValue)
        {
            _stats[key] = newValue;
        }

        public string GetStatsString()
        {
            StringBuilder stringBuilder = new();
            foreach (var (key,value) in _stats)
            {
                stringBuilder.Append(key + ":"+value+"\n");
            }

            return stringBuilder.ToString();
        }
    }
}