using Atomic.Objects;
using Entities;

namespace Lessons.Game.Events
{
    public readonly struct DealDamageEvent : IEvent
    {
        public readonly IAtomicObject Source;
        public readonly IAtomicObject Target;
        public readonly int Damage;

        public DealDamageEvent(IAtomicObject source,IAtomicObject target, int damage)
        {
            Source = source;
            Target = target;
            Damage = damage;
        }
    }
}