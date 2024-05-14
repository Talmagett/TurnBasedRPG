using UnityEngine;

namespace Game.GameEngine.Entities.Scripts.ScriptableObjects
{
    public abstract class ScriptableEntityCondition : ScriptableObject, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
}