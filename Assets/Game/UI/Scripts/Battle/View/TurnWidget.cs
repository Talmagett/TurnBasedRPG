using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Battle.View
{
    public class TurnWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text turnText;
        [SerializeField] private Image time;
        [SerializeField] private Image energy;

        public void SetTurn(string turnValue, bool isActive)
        {
            turnText.text = turnValue;
            //Tween.Rotation(time.transform, Quaternion.Euler(0,0,time.transform.eulerAngles.z+180), 0.4f);
            time.gameObject.SetActive(!isActive);
            energy.gameObject.SetActive(isActive);
            if (isActive)
            {
                Tween.ShakeScale(energy.transform, Vector3.one * 1.2f, 0.3f);
            }
        }
    }
}