using UnityEngine;

namespace Game.UI.Scripts.Views.Map
{
    public class MapHeroView : MonoBehaviour
    {
        [SerializeField] private CharacterIconView iconView;
        // [SerializeField] private SliderView healthView;
        // [SerializeField] private SliderView manaView;

        public void SetIcon(Sprite icon)
        {
            iconView.SetIcon(icon);
        }
        //
        // public void SetHealth(float value)
        // {
        //     healthView.SetFill(value);
        // }
        //
        // public void SetMana(float value)
        // {
        //     manaView.SetFill(value);
        // }
    }
}