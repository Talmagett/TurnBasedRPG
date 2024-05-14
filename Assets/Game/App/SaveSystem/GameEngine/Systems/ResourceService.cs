using System;
using System.Collections.Generic;
using System.Linq;
using Game.App.SaveSystem.GameEngine.Objects;
using Sirenix.OdinInspector;

namespace Game.App.SaveSystem.GameEngine.Systems
{
    //Нельзя менять!
    [Serializable]
    public sealed class ResourceService
    {
        [ShowInInspector] [ReadOnly] private Dictionary<string, Resource> sceneResources = new();

        public void SetResources(IEnumerable<Resource> resources)
        {
            sceneResources = resources.ToDictionary(it => it.ID);
        }

        public IEnumerable<Resource> GetResources()
        {
            return sceneResources.Values;
        }
    }
}