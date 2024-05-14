using SaveSystem.GameEngine.Systems;

namespace SaveSystem.SaveSystem
{
    public abstract class SaveLoader<TData, TService> : ISaveLoader
    {
        void ISaveLoader.LoadGame(IGameRepository repository, GameContext context)
        {
            var service = context.GetService<TService>();
            if (repository.TryGetData(out TData data))
            {
                this.SetupData(service, data);
            }
            else
            {
                this.SetupByDefault(service);
            }
        }

        void ISaveLoader.SaveGame(IGameRepository repository, GameContext context)
        {
            var service = context.GetService<TService>();
            var data = this.ConvertToData(service);
            repository.SetData(data);
        }

        protected abstract void SetupData(TService service, TData loadedUnitsDataArray);

        protected abstract TData ConvertToData(TService service);

        protected virtual void SetupByDefault(TService service)
        {
        }
    }
}