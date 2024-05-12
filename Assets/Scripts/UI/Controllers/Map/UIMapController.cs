using UI.Controllers.TabMenu;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Controllers.Map
{
    public class UIMapController : MonoBehaviour
    {
        [SerializeField] private Button menuBtn;
        [SerializeField] private UITabMenuController uiTabMenuController;

        private void OnEnable()
        {
            menuBtn.onClick.AddListener(OpenTabMenu);
        }

        private void OnDisable()
        {
            menuBtn.onClick.RemoveListener(OpenTabMenu);
        }

        private void OpenTabMenu()
        {
            uiTabMenuController.ShowCharactersList();
        }
    }
}