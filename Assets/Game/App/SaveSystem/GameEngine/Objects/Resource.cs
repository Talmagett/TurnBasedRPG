using UnityEngine;

namespace Game.App.SaveSystem.GameEngine.Objects
{
    //Нельзя менять!
    public sealed class Resource : MonoBehaviour
    {
        [SerializeField] private string id;

        [SerializeField] private int amount;

        public string ID => id;

        public int Amount
        {
            get => amount;
            set => amount = value;
        }
    }
}