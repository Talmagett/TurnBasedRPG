using Data;

namespace Battle.Characters
{
    public class Party
    {
        public Hero[] Heroes { get; private set; }

        public Party(CharacterConfig[] characterConfigs)
        {
            Heroes = new Hero[characterConfigs.Length];
            for (int i = 0; i < characterConfigs.Length; i++)
            {
                Heroes[i] = new Hero(characterConfigs[i]);
            }
        }
    }
}