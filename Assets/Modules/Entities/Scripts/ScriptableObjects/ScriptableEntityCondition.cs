using UnityEngine;

namespace Modules.Entities.Scripts.ScriptableObjects
{
    public abstract class ScriptableEntityCondition : ScriptableObject, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
}