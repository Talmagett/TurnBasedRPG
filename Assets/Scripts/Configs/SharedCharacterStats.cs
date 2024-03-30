using System;
using System.Collections.Generic;

namespace Configs
{
    [Serializable]
    public class SharedCharacterStats
    {
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
        
        public void Init(BaseCharacterStatsConfig stats)
        {
            
        }
    }
}