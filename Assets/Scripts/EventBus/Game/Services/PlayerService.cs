using Entities;
using UnityEngine;

namespace EventBus.Game.Services
{
    public sealed class PlayerService : MonoBehaviour
    {
        public IEntity Player => player;
        
        [SerializeField]
        private MonoEntity player;
    }
}