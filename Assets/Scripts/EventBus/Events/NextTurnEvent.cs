using Battle.Actors;

namespace EventBus.Events
{
    public readonly struct NextTurnEvent : IEvent
    {
        public readonly ActorData CurrentActor;

        public NextTurnEvent(ActorData currentActor=null)
        {
            CurrentActor = currentActor;
        }
    }
}