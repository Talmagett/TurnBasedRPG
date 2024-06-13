using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta.Items.Scripts.ItemModule
{
    [Serializable]
    public sealed class Item
    {
        [SerializeField] private string name;
        [SerializeField][PreviewField(128,ObjectFieldAlignment.Center)] private Sprite icon;
        [SerializeField] private ItemFlags flags;

        [SerializeReference] private object[] components;

        public Item(
            string name,
            Sprite icon,
            ItemFlags flags,
            params object[] components
        )
        {
            this.name = name;
            this.icon = icon;
            this.flags = flags;
            this.components = components;
        }

        public string Name => name;
        public Sprite Icon => icon;
        public ItemFlags Flags => flags;

        public T GetComponent<T>()
        {
            foreach (var component in components)
                if (component is T tComponent)
                    return tComponent;

            throw new Exception($"Component of type {typeof(T).Name} is not found!");
        }

        public T[] GetComponents<T>()
        {
            List<T> getComponents = new();

            foreach (var component in components)
                if (component is T tComponent)
                    getComponents.Add(tComponent);

            return getComponents.ToArray();
        }

        public Item Clone()
        {
            var count = this.components.Length;
            var components = new object[count];

            for (var i = 0; i < count; i++)
            {
                var component = this.components[i];
                if (component is ICloneable cloneable) component = cloneable.Clone();

                components[i] = component;
            }

            return new Item(name, icon, flags, components);
        }
    }
}