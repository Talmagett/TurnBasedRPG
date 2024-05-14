namespace Game.GameEngine.Entities.Scripts
{
    public interface IEntityCondition
    {
        bool IsTrue(IEntity entity);
    }
}