using Battle.EventBus.Game.Events.Effects;
using UnityEngine;

namespace Configs
{
    public abstract class Ability : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: SerializeField] public AnimationKeys.Animation Animation { get; private set; }

        [SerializeReference] public IEffect[] Effects;
    }
}