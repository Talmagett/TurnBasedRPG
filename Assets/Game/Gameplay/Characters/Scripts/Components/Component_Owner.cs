using System;
using Atomic.Elements;
using Configs.Enums;

namespace Character.Components
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