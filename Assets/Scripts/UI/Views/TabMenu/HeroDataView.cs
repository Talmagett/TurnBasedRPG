using UnityEngine;

namespace UI.Views.TabMenu
{
    public class HeroDataView : MonoBehaviour
    {
        [field: SerializeField] public HeroPersonalDataView HeroPersonalDataView { get; private set; }
        [field: SerializeField] public CharacterStatsView CharacterStatsView { get; private set; }
    }
}