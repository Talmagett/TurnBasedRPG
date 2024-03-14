using Map.UI;
using UnityEngine;

namespace Battle.UI
{
    public class BattleQueueView : MonoBehaviour
    {
        [SerializeField] private CharacterIconView iconViewPrefab;
        [SerializeField] private CharacterIconView currentIconView;
        
        [SerializeField] private RectTransform parent;
        
        public void Clear()
        {
            while (parent.childCount>0)
            {
                DestroyImmediate(parent.GetChild(0).gameObject);
            }
        }

        public void SetCurrentTurnView(Sprite icon)
        {
            currentIconView.SetIcon(icon);
        }
        
        public void SetIcon(Sprite icon, float percent)
        {
            var corners = new Vector3[4];
            parent.GetLocalCorners(corners);
            var xPos = (corners[2].x - corners[0].x) * percent;
            var characterIconView = Instantiate(iconViewPrefab,new Vector2(parent.position.x+corners[0].x+xPos,parent.position.y),Quaternion.identity, parent);
            characterIconView.SetIcon(icon);
        }
    }
}