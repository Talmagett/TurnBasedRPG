using System;
using Game.Gameplay.Abilities.Scripts.Effects.Visual;
using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using Game.Gameplay.EventBus.Handlers.Turn;
using JetBrains.Annotations;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Gameplay.EventBus.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class ParticleEffectHandler :  IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        [Inject]
        public ParticleEffectHandler(EventBus eventBus) 
        {
            _eventBus = eventBus;
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<ParticleEffectEvent>(OnParticle);
            _eventBus.Subscribe<ParticleEvent>(OnParticle);
        }
        
        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<ParticleEffectEvent>(OnParticle);
            _eventBus.Unsubscribe<ParticleEvent>(OnParticle);
        }


        private void OnParticle(ParticleEffectEvent evt)
        {
            var effectPoint = evt.Target.Get<BodyParts>().GetPoint(evt.SpawnPoint);
            var vfx = Object.Instantiate(evt.Particle, effectPoint.position, effectPoint.rotation);
            Object.Destroy(vfx.gameObject, evt.Duration);
        }
        
        private void OnParticle(ParticleEvent evt)
        {
            var effectPoint = evt.Target.Get<BodyParts>().GetPoint(evt.SpawnPoint);
            var vfx = Object.Instantiate(evt.Particle, effectPoint.position, effectPoint.rotation);
            Object.Destroy(vfx.gameObject, evt.Duration);
        }
    }
}