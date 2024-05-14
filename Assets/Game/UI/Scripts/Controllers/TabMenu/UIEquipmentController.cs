using Game.Gameplay.Game.Heroes;
using Game.Meta.Inventory.Equipment;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.UI.Scripts.Controllers.TabMenu
{
    public class UIEquipmentController : MonoBehaviour
    {
        [SerializeField] private EquipmentObserver.EquipmentAdapter[] equipmentsStack;

        public void Setup(Hero hero)
        {
            var equipmentPresenter = new EquipmentObserver(hero.Get<Equipment>(), equipmentsStack);
        }
    }
}