using System;
using System.Collections;
using UnityEngine;

namespace UI.Views.TabMenu.Inventory
{
    public class ItemViewTester : MonoBehaviour
    {
        [SerializeField] private ItemView view;

        private IEnumerator Start()
        {
            view.OnPressed += OnPressed;
            yield return new WaitForSeconds(3);
            view.OnPressed -= OnPressed;
        }

        private void OnPressed()
        {
            
        }
    }
}