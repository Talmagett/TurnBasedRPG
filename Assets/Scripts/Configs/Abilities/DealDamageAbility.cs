using Battle.Actors;
using Battle.EventBus.Game;
using Battle.EventBus.Game.Events;
using Configs.Abilities.Attributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Configs.Abilities
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/DealDamageAbility", order = 0)]

    public class DealDamageAbility : Ability
    {
        [SerializeField] private ParticleSystem hitEffect;
        [SerializeField] private BaseValue bonusDamage;
        [SerializeField] private StatMultiplier attackPowerMultiplier;
        public void Process(EventBus eventBus, ActorData source,ActorData target)
        {
            var attackPowerStat = source.SharedStats.GetStat(attackPowerMultiplier.Stat);
            var damage = (int)(bonusDamage.Value +attackPowerMultiplier.Multiplier * attackPowerStat);
            eventBus.RaiseEvent(new DealDamageEvent(source, target, damage));
            eventBus.RaiseEvent(new VisualParticleEvent(target, hitEffect));
        }
    }
}