using Game.Gameplay.Characters.Scripts;

namespace Game.Gameplay.EventBus.Events
{
    public readonly struct NextTurnEvent : IEvent
    {
        public readonly CharacterEntity CurrentActor;

        public NextTurnEvent(CharacterEntity currentActor = null)
        {
            CurrentActor = currentActor;
        }
    }
}