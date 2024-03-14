using UnityEngine;
using View;

namespace Battle.UI
{
    public class BattleQueueView : MonoBehaviour
    {
        [SerializeField] private CharacterIconView iconViewPrefab;
        [SerializeField] private RectTransform parent;
        private float maxX;
        private float minX;

        private void Awake()
        {
            var corners = new Vector3[4];
            parent.GetLocalCorners(corners);
            minX = corners[0].x;
            maxX = corners[2].x;
        }

        public void Clear()
        {
            while (parent.transform.childCount > 0) DestroyImmediate(parent.transform.GetChild(0).gameObject);
        }

        public void SetCurrentTurnView(Sprite icon)
        {
            var characterIconView = SpawnIcon(icon, 0);
            characterIconView.transform.localScale *= 2;
        }

        public CharacterIconView SpawnIcon(Sprite icon, float percent)
        {
            var xPos = (maxX - minX) * percent;
            var position = parent.position;
            var characterIconView =
                Instantiate(iconViewPrefab, new Vector2(position.x + minX + xPos, position.y), Quaternion.identity,
                    parent);
            characterIconView.SetIcon(icon);
            return characterIconView;
        }
    }
}