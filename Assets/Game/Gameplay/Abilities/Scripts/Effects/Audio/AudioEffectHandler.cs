using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class AudioEffectHandler : BaseHandler<AudioEffectEvent>
    {
        public AudioEffectHandler(EventBus eventBus) : base(eventBus)
        {
            
        }

        protected override void HandleEvent(AudioEffectEvent evt)
        {
            AudioSource.PlayClipAtPoint(evt.AudioClip, evt.Target.Get<Transform>().position);
        }
    }
}