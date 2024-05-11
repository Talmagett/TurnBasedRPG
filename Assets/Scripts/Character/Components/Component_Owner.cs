using System;
using Atomic.Elements;
using Configs.Enums;
using UnityEngine.Serialization;

namespace Battle.Actors.Model
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