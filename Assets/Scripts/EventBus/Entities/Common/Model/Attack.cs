using System;
using EventBus.Game;
using EventBus.Utils;

namespace EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<Weapon> weapon;
    }
}