using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CharacterCreator2D.UI
{
    [RequireComponent(typeof(ScrollRect))]
    public class DropdownAutoScroller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private bool _mouseHover;
        private RectTransform contentPanel;
        private GameObject lastSelected;
        private RectTransform scrollRectTransform;
        private RectTransform selectedRectTransform;

        private Vector2 targetPos;

        private void Start()
        {
            scrollRectTransform = GetComponent<RectTransform>();

            if (contentPanel == null)
                contentPanel = GetComponent<ScrollRect>().content;

            targetPos = contentPanel.anchoredPosition;
        }

        private void Update()
        {
            if (!_mouseHover)
                Autoscroll();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _mouseHover = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _mouseHover = false;
        }

        public void Autoscroll()
        {
            if (contentPanel == null)
                contentPanel = GetComponent<ScrollRect>().content;

            var selected = EventSystem.current.currentSelectedGameObject;

            if (selected == null) return;
            if (selected.transform.parent != contentPanel.transform) return;
            if (selected == lastSelected) return;

            selectedRectTransform = (RectTransform)selected.transform;
            targetPos.x = contentPanel.anchoredPosition.x;
            targetPos.y = -selectedRectTransform.localPosition.y - selectedRectTransform.rect.height / 2;
            targetPos.y = Mathf.Clamp(targetPos.y, 0, contentPanel.sizeDelta.y - scrollRectTransform.sizeDelta.y);

            contentPanel.anchoredPosition = targetPos;
            lastSelected = selected;
        }
    }
}