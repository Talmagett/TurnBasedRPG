namespace Commands
{
    internal class SkipCommand : Command
    {
        public SkipCommand()
        {
        }
        public override void Execute()
        {}
        public override bool IsFinished => true;
    }
}