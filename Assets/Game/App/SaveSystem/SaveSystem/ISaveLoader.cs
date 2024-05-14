using SaveSystem.GameEngine.Systems;

namespace SaveSystem.SaveSystem
{
    public interface ISaveLoader
    {
        void LoadGame(IGameRepository repository, GameContext context);

        void SaveGame(IGameRepository repository, GameContext context);
    }
}