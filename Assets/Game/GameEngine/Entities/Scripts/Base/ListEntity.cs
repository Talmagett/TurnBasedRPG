using System.Collections.Generic;

namespace Game.GameEngine.Entities.Scripts.Base
{
    public class ListEntity : IEntity
    {
        private readonly List<object> elements;

        public ListEntity()
        {
            elements = new List<object>();
        }

        public ListEntity(IEnumerable<object> elements)
        {
            this.elements = new List<object>(elements);
        }

        public ListEntity(params object[] elements)
        {
            this.elements = new List<object>(elements);
        }

        public T Get<T>()
        {
            for (int i = 0, count = elements.Count; i < count; i++)
                if (elements[i] is T result)
                    return result;

            throw new EntityException($"Element of type {typeof(T).Name} is not found!");
        }

        public object[] GetAll()
        {
            return elements.ToArray();
        }

        public bool TryGet<T>(out T element)
        {
            for (int i = 0, count = elements.Count; i < count; i++)
                if (elements[i] is T result)
                {
                    element = result;
                    return true;
                }

            element = default;
            return false;
        }

        public T[] GetAll<T>()
        {
            var result = new List<T>();
            for (int i = 0, count = elements.Count; i < count; i++)
                if (elements[i] is T element)
                    result.Add(element);

            return result.ToArray();
        }

        public void Add(object element)
        {
            elements.Add(element);
        }

        public void AddRange(IEnumerable<object> elements)
        {
            this.elements.AddRange(elements);
        }

        public void AddRange(params object[] elements)
        {
            this.elements.AddRange(elements);
        }

        public void Remove(object element)
        {
            elements.Remove(element);
        }
    }
}