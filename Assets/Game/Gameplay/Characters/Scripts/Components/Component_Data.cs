using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [Serializable]
    public sealed class Component_Data
    {
        public AtomicVariable<string> name;
        public AtomicVariable<string> description;
        public AtomicVariable<Sprite> icon;

        public Component_Data(AtomicVariable<string> name, AtomicVariable<string> description, AtomicVariable<Sprite> icon)
        {
            this.name = name;
            this.description = description;
            this.icon = icon;
        }
    }
}