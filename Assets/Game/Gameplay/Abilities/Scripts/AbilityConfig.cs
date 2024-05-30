using Game.Gameplay.Characters.Scripts.Keys;
using Game.Gameplay.EventBus.Events.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Abilities.Scripts
{
    [CreateAssetMenu(menuName = "SO/Create AbilityConfig", fileName = "AbilityConfig", order = 0)]
    public class AbilityConfig : ScriptableObject
    {
        [field: SerializeField]
        [field: Title("Configs")]
        public string ID { get; private set; }

        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: SerializeField]
        [field: Title("Configs")] public int TurnEnergyCost { get; private set; }
        [field: SerializeField] public float TurnProcessTime { get; private set; }
        [field: SerializeField] public int ManaCost { get; private set; }
        [field: SerializeField] public AbilityTargetType TargetType { get; private set; }
        [field: SerializeField] public AnimationKey.Animation AnimationKey { get; private set; }

        [Title("Effects")] [SerializeReference]
        public IEffect[] Effects;
    }
}