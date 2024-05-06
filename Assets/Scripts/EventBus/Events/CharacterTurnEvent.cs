using Battle.Actors;

namespace EventBus.Events
{
    public readonly struct CharacterTurnEvent : IEvent
    {
        public readonly ActorData ActorData;

        public CharacterTurnEvent(ActorData actorData)
        {
            ActorData = actorData;
        }
    }
}