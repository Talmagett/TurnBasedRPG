namespace Battle.Characters
{
    public interface IBattleTurn
    {
        void StartTurn();
        bool HasFinished();
        void EndTurn();
    }
}