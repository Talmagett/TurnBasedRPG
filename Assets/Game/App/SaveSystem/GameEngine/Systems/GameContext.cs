using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Zenject;

namespace Game.App.SaveSystem.GameEngine.Systems
{
    [UsedImplicitly]
    public class GameContext
    {
        private readonly Dictionary<Type, object> _services = new();

        [Inject]
        public GameContext(UnitManager unitManager, ResourceService resourceManager)
        {
            _services.Add(typeof(UnitManager), unitManager);
            _services.Add(typeof(ResourceService), resourceManager);
        }

        public TService GetService<TService>()
        {
            if (_services.ContainsKey(typeof(TService))) return (TService)_services[typeof(TService)];

            throw new NullReferenceException("No such service");
        }
    }
}