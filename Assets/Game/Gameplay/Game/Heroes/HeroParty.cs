using Game.Gameplay.Characters.Scripts.SO;
using JetBrains.Annotations;

namespace Game.Gameplay.Game.Heroes
{
    [UsedImplicitly]
    public class HeroParty
    {
        public readonly Hero[] HeroDataArray;

        public HeroParty(HeroCharacterConfig[] configs)
        {
            HeroDataArray = new Hero[configs.Length];
            for (var i = 0; i < configs.Length; i++) HeroDataArray[i] = new Hero(configs[i]);
        }
    }
}