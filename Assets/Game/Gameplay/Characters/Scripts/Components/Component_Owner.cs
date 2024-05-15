using System;
using Atomic.Elements;
using Game.Gameplay.Characters.Scripts.Keys;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [Serializable]
    public sealed class Component_Owner
    {
        public AtomicVariable<Owner> owner;

        public Component_Owner(Owner value)
        {
            owner = new AtomicVariable<Owner>(value);
        }
    }
}