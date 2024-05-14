using Game.App.SaveSystem.GameEngine.Systems;

namespace Game.App.SaveSystem.SaveSystem
{
    public interface ISaveLoader
    {
        void LoadGame(IGameRepository repository, GameContext context);

        void SaveGame(IGameRepository repository, GameContext context);
    }
}