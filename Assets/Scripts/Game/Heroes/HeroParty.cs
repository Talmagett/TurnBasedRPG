using Configs.Character;
using JetBrains.Annotations;

namespace Game.Heroes
{
    [UsedImplicitly]
    public class HeroParty
    {
        public readonly HeroesData[] HeroDataArray;

        public HeroParty(CharacterConfig[] configs)
        {
            HeroDataArray = new HeroesData[configs.Length];
            for (var i = 0; i < configs.Length; i++) HeroDataArray[i] = new HeroesData(configs[i]);
        }
    }
}