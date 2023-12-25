using System;
using Battle.Player;
using UnityEngine;

namespace Battle
{
    public class ServiceLocator:MonoBehaviour
    {
        public static ServiceLocator Instance { get; private set; }

        [SerializeField] private PlayerController playerController;
        private void Awake()
        {
            if(Instance!=null)
                Destroy(Instance);
            Instance = this;
        }

        public PlayerController GetPlayerController()
        {
            return playerController;
        }
    }
}