using System;
using System.Linq;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Abilities.Scripts;
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
                        IEntity randomTarget;
                        switch (data.AbilityTargetType)
                        {
                            case AbilityTargetType.Self:
                                throw new Exception($"Wrong spell with Self {data.AbilityTargetType}");
                            case AbilityTargetType.Enemy:
                                randomTarget =_battleContainer.GetRandomEnemy(data.Source);
                                break;
                            case AbilityTargetType.AllyOnly:
                                do
                                {
                                    randomTarget = _battleContainer.GetRandomAlly(data.Source);
                                } while (randomTarget == data.Source);
                                break;
                            case AbilityTargetType.AllyAndSelf:
                                randomTarget =_battleContainer.GetRandomAlly(data.Source);
                                break;
                            case AbilityTargetType.Any:
                                randomTarget =_battleContainer.GetRandomCharacter();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        Cast(data.Effects.Clone() as IEffect[], data.Source, randomTarget,data.Delay * i);
                    }
                    break;
                case MultiEffectEvent.MultiType.All:
                    IEntity[] targets;
                    switch (data.AbilityTargetType)
                    {
                        case AbilityTargetType.Self:
                            throw new Exception($"Wrong spell with Self {data.AbilityTargetType}");
                        case AbilityTargetType.Enemy:
                            targets = _battleContainer.GetAllEnemies(data.Source);
                            break;
                        case AbilityTargetType.AllyOnly:
                            targets =_battleContainer.GetAllAllies(data.Source);
                            targets.ToList().Remove(data.Source);
                            break;
                        case AbilityTargetType.AllyAndSelf:
                            targets =_battleContainer.GetAllAllies(data.Source);
                            break;
                        case AbilityTargetType.Any:
                            targets =_battleContainer.GetAllCharacters();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    var enemiesCount = data.Count < targets.Length ? data.Count : targets.Length;
                    for (var i = 0; i < enemiesCount; i++)
                    {
                        var target = targets[i];
                        Cast(data.Effects.Clone() as IEffect[], data.Source, target,data.Delay * i);
                    }
                    break;
            }
        }
    }
}