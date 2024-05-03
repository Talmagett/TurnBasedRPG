using UnityEngine;

namespace Visual.UI.TabMenu
{
    public class HeroDataView : MonoBehaviour
    {
        [field:SerializeField] public HeroPersonalDataView HeroPersonalDataView { get; private set; }
        [field:SerializeField] public HeroStatsView HeroStatsView { get; private set; }
    }
}