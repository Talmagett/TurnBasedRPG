using UnityEngine;
using Zenject;

namespace Game
{
    public abstract class GameStateController : MonoBehaviour
    {
        [SerializeField] private Camera stateCamera;
        [SerializeField] private GameObject canvas;

        protected PlayerInputActions PlayerInputActions;

        [Inject]
        public void Construct(PlayerInputActions playerInputActions)
        {
            PlayerInputActions = playerInputActions;
        }

        public virtual void EnterState()
        {
            canvas.SetActive(true);
            stateCamera.gameObject.SetActive(true);   
        }

        public virtual void ExitState()
        {
            canvas.SetActive(false);
            stateCamera.gameObject.SetActive(false);
        }
    }
}