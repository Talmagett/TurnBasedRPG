using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Characters.Scripts.BodyParts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct ShootProjectileEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }

        [field: SerializeField] public GameObject Projectile { get; private set; }
        [field: SerializeField] public BodyParts.Key ProjectileShootPoint { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }
        [field: SerializeReference] public IEffect[] EffectsOnHit { get; private set; }
    }
}