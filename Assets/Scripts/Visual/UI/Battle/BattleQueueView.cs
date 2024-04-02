using UnityEngine;
using UnityEngine.UI;

namespace Visual.UI.Battle
{
    public class BattleQueueView : MonoBehaviour
    {
        [SerializeField] private Image iconImage;

        public void SetIcon(Sprite icon)
        {
            iconImage.sprite = icon;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void SetScale(float value)
        {
            transform.localScale = Vector3.one * value;
        }
    }
}