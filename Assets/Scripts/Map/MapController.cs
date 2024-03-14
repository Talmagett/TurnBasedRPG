using Game;

namespace Map
{
    public class MapController : GameStateController
    {
        public override void EnterState()
        {
            base.EnterState();
            PlayerInputActions.Map.Enable();
        }

        public override void ExitState()
        {
            base.ExitState();
            PlayerInputActions.Map.Disable();
        }
    }
}