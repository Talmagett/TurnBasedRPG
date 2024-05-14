using UnityEngine;

namespace CharacterCreator2D.UI
{
    public class UIColor : MonoBehaviour
    {
        /// <summary>
        ///     Current mode of this UIColor. Tells whether UIColor is opening color palette or color picker.
        /// </summary>
        [Tooltip("Current mode of this UIColor. Tells whether UIColor is opening color palette or color picker")]
        [ReadOnly]
        public UIColorMode mode;

        [ReadOnly] public Color selectedColor;

        /// <summary>
        ///     UIColorPalette managed by this UIColor.
        /// </summary>
        [Tooltip("UIColorPalette managed by this UIColor")]
        public UIColorPalette colorPalette;

        /// <summary>
        ///     UIColorPicker managed by this UIColor.
        /// </summary>
        [Tooltip("UIColorPicker managed by this UIColor")]
        public UIColorPicker colorPicker;

        /// <summary>
        ///     Scrollbar controlling color palette's contents
        /// </summary>
        [Tooltip("Scrollbar controlling color palette's contents")]
        public Transform scrollBar;

        private void Update()
        {
            switch (mode)
            {
                case UIColorMode.Palette:
                    selectedColor = colorPalette.color;
                    colorPicker.color = colorPalette.color;
                    break;
                case UIColorMode.Picker:
                    selectedColor = colorPicker.color;
                    colorPalette.color = colorPicker.color;
                    break;
            }
        }

        /// <summary>
        ///     Show this UIColor.
        /// </summary>
        public void Show()
        {
            Show(selectedColor);
        }

        /// <summary>
        ///     Show this UIColor.
        /// </summary>
        /// <param name="currentColor">Initiated color to be showed.</param>
        public void Show(Color currentColor)
        {
            selectedColor = currentColor;
            colorPalette.color = selectedColor;
            colorPicker.color = selectedColor;
            setMode(mode);
            gameObject.SetActive(true);
        }

        /// <summary>
        ///     Close this UIColor.
        /// </summary>
        public void Close()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        ///     Show color palette and close color picker.
        /// </summary>
        public void ShowColorPalette()
        {
            setMode(UIColorMode.Palette);
        }

        /// <summary>
        ///     Show color picker and close color palette.
        /// </summary>
        public void ShowColorPicker()
        {
            setMode(UIColorMode.Picker);
        }

        private void setMode(UIColorMode colorMode)
        {
            mode = colorMode;
            switch (mode)
            {
                case UIColorMode.Palette:
                    colorPalette.gameObject.SetActive(true);
                    colorPicker.gameObject.SetActive(false);
                    scrollBar.gameObject.SetActive(true);
                    break;
                case UIColorMode.Picker:
                    colorPalette.gameObject.SetActive(false);
                    colorPicker.gameObject.SetActive(true);
                    scrollBar.gameObject.SetActive(false);
                    break;
                default:
                    colorPalette.gameObject.SetActive(false);
                    colorPicker.gameObject.SetActive(false);
                    scrollBar.gameObject.SetActive(false);
                    break;
            }
        }
    }

    public static class Clipboard
    {
        public static Color color = Color.clear;
    }
}