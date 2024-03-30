using Battle.EventBus.Entities.Common.Model;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class StatsComponent
    {
        private readonly Stats _stats;

        public StatsComponent(Stats stats)
        {
            _stats = stats;
        }

        public int Strength => _stats.strength;
    }
}