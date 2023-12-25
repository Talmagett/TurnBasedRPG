namespace Commands
{
    public abstract class Command
    {
        public abstract void Execute();
        public abstract bool IsFinished { get; }
    }
}