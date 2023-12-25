using UnityEngine;
namespace Data
{
    public class Hero
    {
        public bool IsDead => Stats.Health == 0;
        public StatsData Stats;
    }
}