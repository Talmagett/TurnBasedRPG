using System;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts
{
    public class AnimatorDispatcher : MonoBehaviour
    {
        public event Action AnimationEvent;

        public void ClearListeners()
        {
            AnimationEvent = null;
        }

        public void ReceiveEvent()
        {
            AnimationEvent?.Invoke();
        }
    }
}