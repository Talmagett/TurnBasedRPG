using Configs.Character;
using UnityEngine;

namespace Configs.Items
{
    [CreateAssetMenu(menuName = "SO/Create ItemConfig", fileName = "ItemConfig", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public string Id;
        public string Description;

        public Stat[] Stats;
    }
}