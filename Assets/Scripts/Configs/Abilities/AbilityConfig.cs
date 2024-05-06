using Battle.Actors;
using Configs.Enums;
using EventBus.Events.Effects;
using UnityEngine;

namespace Configs.Abilities
{
    public abstract class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int EnergyCost { get; private set; }
        [field: SerializeField] public AbilityTargetType TargetType { get; private set; }

        [field: SerializeField] public AnimationKey.Animation AnimationKey { get; private set; }

        [SerializeReference] public IEffect[] Effects;

        public abstract IAbility GetAbilityClone(ActorData source, ActorData target);
    }
}