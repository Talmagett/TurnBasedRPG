using UnityEngine;

namespace Visual.UI.TabMenu
{
    public class HeroStatsView : MonoBehaviour
    {
        [field: SerializeField] public StatView MaxHealth { get; private set; }
        [field: SerializeField] public StatView MaxMana { get; private set; }
        [field: SerializeField] public StatView Attack { get; private set; }
        [field: SerializeField] public StatView Defense { get; private set; }
    }
}