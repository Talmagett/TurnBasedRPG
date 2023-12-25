using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class ButtonIconTextUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button button;

        public void SetData(Sprite icon,string textData,Action onClick)
        {
            image.sprite = icon;
            text.text = textData;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(()=>onClick());
        }
    }
}