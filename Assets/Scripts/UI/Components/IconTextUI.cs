using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class IconTextUI: MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text text;

        public void SetData(Sprite icon,string textData)
        {
            image.sprite = icon;
            text.text = textData;
        }
    }
}