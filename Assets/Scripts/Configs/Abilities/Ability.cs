using System;
using Battle.EventBus.Game.Events.Effects;
using Configs.Enums;
using UnityEngine;

namespace Configs.Abilities
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability", order = 0)]
    [Serializable]
    public class Ability : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: SerializeField] public AnimationKey.Animation Animation { get; private set; }
        
        [SerializeReference] public IEffect[] Effects;
    }
}