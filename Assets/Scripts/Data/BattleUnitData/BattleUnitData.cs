using Battle.AbilityContainers;
using UnityEngine;

namespace Data.BattleUnitData
{
    [CreateAssetMenu(menuName = "SO/BattleUnitData")]
    public class BattleUnitData: ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public AbilityContainer[] AbilityContainers { get; private set; }
    }
}