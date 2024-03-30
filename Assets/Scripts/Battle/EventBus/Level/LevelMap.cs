using JetBrains.Annotations;

namespace Battle.EventBus.Level
{
    [UsedImplicitly]
    public sealed class LevelMap
    {
        public LevelMap(EntityMap entities, TileMap tiles)
        {
            Entities = entities;
            Tiles = tiles;
        }

        public EntityMap Entities { get; }

        public TileMap Tiles { get; }
    }
}