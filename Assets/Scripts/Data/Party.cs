using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class Party
    {
        private const int maxCount=4;
        public Hero[] Heroes = new Hero[maxCount];
        private List<HeroData> _heroes = new List<HeroData>();
        public event Action<List<HeroData>> OnHeroesChanged;
        public void PickUnpickHero(HeroData data)
        {
            if (_heroes.Contains(data))
                _heroes.Remove(data);
            else
                _heroes.Add(data);
            OnHeroesChanged?.Invoke(_heroes);
        }
    }
}