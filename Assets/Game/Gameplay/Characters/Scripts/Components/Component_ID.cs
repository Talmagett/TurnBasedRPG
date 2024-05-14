using System;
using Atomic.Elements;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [Serializable]
    public sealed class Component_ID
    {
        public readonly AtomicVariable<string> id;

        public Component_ID(string value)
        {
            id = new AtomicVariable<string>(value);
        }
    }
}