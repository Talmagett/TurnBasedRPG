using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Hero/StaticData")]
    public class HeroData : ScriptableObject
    {
        [SerializeField] private string heroName;
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;
        
        public string HeroName => heroName;
        public string Description => description;
        public Sprite Icon => icon;
    }
}