using PrimeTween;
using UnityEngine;

namespace Visual.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup loadingPanel;

        public void Open()
        {
            loadingPanel.gameObject.SetActive(true);
            Tween.Alpha(loadingPanel, 1,0.2f);
        }

        public void Close()
        {
            Tween.Alpha(loadingPanel, 0,0.2f).OnComplete(
                ()=>loadingPanel.gameObject.SetActive(false)
            );
        }
    }
}