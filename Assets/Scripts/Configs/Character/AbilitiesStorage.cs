using Configs.Abilities;
using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(menuName = "SO/AbilitiesList", fileName = "AbilitiesList", order = 0)]
    public class AbilitiesStorage : ScriptableObject
    {
        public AbilitiesPack[] AbilitiesPacks;
        [System.Serializable]
        public class AbilitiesPack
        {
            public string ID;
            public AbilityConfig[] Abilities;
        }
    }
}