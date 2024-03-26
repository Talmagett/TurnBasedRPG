using EventBus.Game.Events.Effects;
using UnityEngine;

namespace EventBus.Game
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "SO/Ability", order = 0)]
    public class AbilityConfig : ScriptableObject
    {
        public string Name;
        public string Description;
        public Sprite Icon;
        
        [SerializeReference]
        public IEffect[] Effects;
    }
}