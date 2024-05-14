using System.Linq;
using Game.App.SaveSystem.GameEngine.Objects;
using Game.App.SaveSystem.GameEngine.Systems;
using Game.App.SaveSystem.SaveSystem;

namespace Game.App.SaveSystem.SaveLoaders
{
    public sealed class ResourcesSaveLoader : SaveLoader<ResourceData[], ResourceService>
    {
        protected override void SetupData(ResourceService resourceService, ResourceData[] loadedUnitsDataArray)
        {
            var resources = resourceService.GetResources().ToArray();
            for (var i = 0; i < loadedUnitsDataArray.Length; i++)
                if (resources[i].ID == loadedUnitsDataArray[i].id)
                    resources[i].Amount = loadedUnitsDataArray[i].amount;
            resourceService.SetResources(resources);
        }

        protected override ResourceData[] ConvertToData(ResourceService resourceService)
        {
            var resources = resourceService.GetResources().ToArray();
            var resourcesData = new ResourceData[resources.Length];
            for (var i = 0; i < resources.Length; i++)
            {
                resourcesData[i].id = resources[i].ID;
                resourcesData[i].amount = resources[i].Amount;
            }

            return resourcesData;
        }
    }
}