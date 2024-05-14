using System;
using System.Collections.Generic;
using Game.Gameplay.EventBus.Events;
using UnityEngine;

namespace Game.Gameplay.EventBus
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, IEventHandlerCollection> _handlers = new();

        private static readonly Queue<IEvent> _queue = new();

        private static bool _isRunning;

        public static void Subscribe<T>(Action<T> handler)
        {
            var eventType = typeof(T);

            if (!_handlers.ContainsKey(eventType)) _handlers.Add(eventType, new EventHandlerCollection<T>());

            _handlers[eventType].Subscribe(handler);
        }

        public static void Unsubscribe<T>(Action<T> handler)
        {
            var eventType = typeof(T);

            if (_handlers.TryGetValue(eventType, out var handlers)) handlers.Unsubscribe(handler);
        }

        public static void RaiseEvent<T>(T evt) where T : IEvent
        {
            if (_isRunning)
            {
                _queue.Enqueue(evt);
                return;
            }

            _isRunning = true;

            var eventType = evt.GetType();
            Debug.Log(eventType);

            if (!_handlers.TryGetValue(eventType, out var handlers))
            {
                Debug.Log($"No subscribers found in: {eventType}");
                _isRunning = false;
                return;
            }

            handlers.RaiseEvent(evt);

            _isRunning = false;

            if (_queue.TryDequeue(out var result)) RaiseEvent(result);
        }

        private interface IEventHandlerCollection
        {
            public void Subscribe(Delegate handler);

            public void Unsubscribe(Delegate handler);

            public void RaiseEvent<T>(T evt);
        }

        private sealed class EventHandlerCollection<T> : IEventHandlerCollection
        {
            private readonly List<Delegate> _handlers = new();

            private int _currentIndex = -1;

            public void Subscribe(Delegate handler)
            {
                _handlers.Add(handler);
            }

            public void Unsubscribe(Delegate handler)
            {
                var index = _handlers.IndexOf(handler);
                _handlers.RemoveAt(index);

                if (index <= _currentIndex) _currentIndex--;
            }

            public void RaiseEvent<TEvent>(TEvent evt)
            {
                if (evt is not T concreteEvent) return;

                for (_currentIndex = 0; _currentIndex < _handlers.Count; _currentIndex++)
                {
                    var handler = (Action<T>)_handlers[_currentIndex];
                    handler.Invoke(concreteEvent);
                }

                _currentIndex = -1;
            }
        }
    }
}