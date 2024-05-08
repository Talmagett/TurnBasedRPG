using System;
using Configs.Enums;

namespace Battle.Actors.Model
{
    [Serializable]
    public sealed class Ownership
    {
        public Owner Owner;

        public Ownership(Owner owner)
        {
            Owner = owner;
        }
    }
}