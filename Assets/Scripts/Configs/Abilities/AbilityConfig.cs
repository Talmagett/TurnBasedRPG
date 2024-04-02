using Battle.Actors;
using Battle.EventBus.Game;
using Battle.EventBus.Game.Events.Effects;
using Configs.Enums;
using UnityEngine;

namespace Configs.Abilities
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability", order = 0)]
    public class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public AbilityTargetType TargetType { get; private set; }

        [field: SerializeField] public AnimationKey.Animation Animation { get; private set; }

        [SerializeReference] public IEffect[] Effects;

        public virtual void Process(EventBus eventBus, ActorData source, ActorData target)
        {
        }
    }
}