using System;

namespace Modules.Entities.Scripts
{
    public sealed class EntityException : Exception
    {
        public EntityException(string message) : base(message)
        {
        }
    }
}