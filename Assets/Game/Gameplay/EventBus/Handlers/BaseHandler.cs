using System;
using Zenject;

namespace Game.Gameplay.EventBus.Handlers
{
    public abstract class BaseHandler<T> : IInitializable, IDisposable
    {
        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<T>(HandleEvent);
        }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<T>(HandleEvent);
        }

        protected abstract void HandleEvent(T evt);
    }
}