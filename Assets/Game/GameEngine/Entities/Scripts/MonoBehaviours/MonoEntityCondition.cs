using UnityEngine;

namespace Modules.Entities.Scripts.MonoBehaviours
{
    public abstract class MonoEntityCondition : MonoBehaviour, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
}