namespace Modules.Entities.Scripts
{
    public interface IEntityCondition
    {
        bool IsTrue(IEntity entity);
    }
}