using System;
using UnityEngine;

namespace Battle.Actors
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