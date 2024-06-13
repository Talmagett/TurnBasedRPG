using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Battle;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.EventBus.Handlers.Effects
{
    public class MultiEffectHandler : IInitializable, IDisposable
    {
        private readonly BattleContainer _battleContainer;
        private readonly EventBus _eventBus;

        [Inject]
        public MultiEffectHandler(BattleContainer battleContainer, EventBus eventBus)
        {
            _battleContainer = battleContainer;
            _eventBus = eventBus;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<MultiEffectEvent>(OnCast);
        }

        public void Initialize()
        {
            _eventBus.Subscribe<MultiEffectEvent>(OnCast);
        }

        private void Cast(IEffect[] effects, IEntity source, IEntity target, float dataDelay)
        {
            foreach (var e in effects)
            {
                var effect = e.Clone();
                effect.Source = source;
                effect.Target = target;
                _eventBus.RaiseEvent(new DelayedEvent(effect, dataDelay));
            }
        }
        private void OnCast(MultiEffectEvent data)
        {
            switch (data.TargetType)
            {
                case MultiEffectEvent.MultiType.Single:
                    for (var i = 0; i < data.Count; i++)
                    {
                        Cast(data.Effects.Clone() as IEffect[], data.Source, data.Target,data.Delay * i);
                    }
                    break;
                case MultiEffectEvent.MultiType.Random:
                    for (var i = 0; i < data.Count; i++)
                    {
                        var randomEnemy=_battleContainer.GetRandomEnemy(data.Source);
                        Cast(data.Effects.Clone() as IEffect[], data.Source, randomEnemy,data.Delay * i);
                    }
                    break;
                case MultiEffectEvent.MultiType.All:
                    var enemies = _battleContainer.GetAllEnemies(data.Source);
                    var enemiesCount = data.Count < enemies.Length ? data.Count : enemies.Length;
                    for (var i = 0; i < enemiesCount; i++)
                    {
                        var enemy = enemies[i];
                        Cast(data.Effects.Clone() as IEffect[], data.Source, enemy,data.Delay * i);
                    }
                    break;
            }
        }
    }
}