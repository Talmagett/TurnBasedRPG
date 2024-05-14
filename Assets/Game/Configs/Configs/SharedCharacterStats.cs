using System;
using System.Collections.Generic;
using Atomic.Elements;
using Configs.Enums;
using Sirenix.OdinInspector;

namespace Configs
{
    [Serializable]
    public class SharedCharacterStats : ShowOdinSerializedPropertiesInInspectorAttribute
    {
        [ReadOnly] private Dictionary<StatKey, AtomicVariable<float>> _stats;

        public SharedCharacterStats(Dictionary<StatKey, float> values)
        {
            _stats = new Dictionary<StatKey, AtomicVariable<float>>();
            foreach (var (stat, value) in values) _stats.Add(stat, new AtomicVariable<float>(value));
        }

        public Dictionary<StatKey, float> GetAllStats()
        {
            Dictionary<StatKey, float> stats = new();
            foreach (var (key, value) in _stats) stats.Add(key, value.Value);
            return stats;
        }

        public AtomicVariable<float> GetStat(StatKey key)
        {
            return _stats[key];
        }

        public void SetStat(StatKey key, float newValue)
        {
            _stats[key].Value = newValue;
        }
    }
}