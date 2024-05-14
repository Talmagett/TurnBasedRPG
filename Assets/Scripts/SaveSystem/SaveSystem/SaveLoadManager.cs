using JetBrains.Annotations;
using SaveSystem.GameEngine.Systems;
using Zenject;

namespace SaveSystem.SaveSystem
{
    [UsedImplicitly]
    public sealed class SaveLoadManager
    {
        private ISaveLoader[] _saveLoaders;
        private GameRepository _repository;
        private GameContext _gameContext;

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, GameRepository repository, GameContext gameContext)
        {
            _saveLoaders = saveLoaders;
            _repository = repository;
            _gameContext = gameContext;
        }

        public void Load()
        {
            _repository.LoadState();
            foreach (var saveLoader in _saveLoaders)
                saveLoader.LoadGame(_repository, _gameContext);
        }

        public void Save()
        {
            foreach (var saveLoader in _saveLoaders)
                saveLoader.SaveGame(_repository, _gameContext);

            _repository.SaveState();
        }
    }
}