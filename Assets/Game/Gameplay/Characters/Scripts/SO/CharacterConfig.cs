using System.Collections.Generic;
using Game.Gameplay.Characters.Scripts.Components;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts.SO
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "SO/CharacterConfig", order = 0)]
    public abstract class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] [field: Space] public CharacterEntity Prefab { get; private set; }
        [field: Space]
        [field: SerializeField] public Component_ID ComponentID { get; private set; }
        [field: SerializeField] public Component_Life ComponentLife { get; private set; }
        [field: SerializeField] public Component_Mana ComponentMana { get; private set; }
        [field: SerializeField] public Component_Attack ComponentAttack { get; private set; }
        [field: SerializeField] public Component_Defense ComponentDefense { get; private set; }
        [field: SerializeField] public Component_Owner ComponentOwner { get; private set; }
        
        public IList<object> CloneComponents()
        {
            return new List<object>()
            {
                new Component_ID(ComponentID.id.Value),
                new Component_Life(ComponentLife.maxHealth.Value),
                new Component_Mana(ComponentMana.maxMana.Value),
                new Component_Attack((int)ComponentAttack.attackPower.Value,ComponentAttack.criticalChance.Value,ComponentAttack.criticalRate.Value),
                new Component_Defense((int)ComponentDefense.defense.Value,ComponentDefense.evasion.Value),
                new Component_Owner(ComponentOwner.owner.Value),
                new Component_Turn(Random.Range(1, 6)),
            };
        }
    }
}