using Game.Gameplay.Game.Heroes;
using Game.Meta.Inventory.Equipment;
using UnityEngine;

namespace Game.UI.Scripts.Controllers.TabMenu
{
    public class UIEquipmentController : MonoBehaviour
    {
        [SerializeField] private EquipmentView equipmentView;

        public void Setup(Hero hero)
        {
            var equipmentPresenter = new EquipmentPresenter(hero.Get<Equipment>(), equipmentView);
        }
    }
}