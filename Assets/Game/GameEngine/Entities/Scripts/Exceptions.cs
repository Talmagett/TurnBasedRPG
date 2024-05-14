using System;

namespace Game.GameEngine.Entities.Scripts
{
    public sealed class EntityException : Exception
    {
        public EntityException(string message) : base(message)
        {
        }
    }
}