using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Scripts.Battle.View
{
    public class TurnWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text turnText;
        [SerializeField] private Image time;
        [SerializeField] private Image energy;

        public void SetTurn(string turnValue, bool isActive)
        {
            turnText.text = turnValue;
            //not working !!??
            Tween.EulerAngles(transform, Vector3.zero, new Vector3(0, 360), 0.3f);
            turnText.gameObject.SetActive(!isActive);
            energy.gameObject.SetActive(isActive);
            if (isActive)
                Tween.ShakeScale(energy.transform, Vector3.one * 1.2f, 0.3f);
        }
    }
}