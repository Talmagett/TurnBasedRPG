using Entities;
using UnityEngine;

namespace Battle.EventBus.Game.Services
{
    public sealed class PlayerService : MonoBehaviour
    {
        [SerializeField] private MonoEntity player;

        public IEntity Player => player;
    }
}