using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class CommandView : MonoBehaviour {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button btn;
    
        public void SetData(Sprite icon, string title, Action onClick)
        {
            image.sprite=icon;
            text.text=title;
            btn.onClick.AddListener(()=>onClick());
        }
        
        //TODO: При наведении на способность вдиен радиус способности
        //TODO: описание
    }
}