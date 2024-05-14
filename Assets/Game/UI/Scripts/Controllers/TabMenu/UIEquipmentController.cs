using Game.Heroes;
using Modules.Items.Scripts.Equipment;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class UIEquipmentController : MonoBehaviour
    {
        [SerializeField] private EquipmentView equipmentView;
        
        public void Setup(Hero hero)
        {
            var equipmentPresenter = new EquipmentPresenter(hero.Get<Equipment>(),equipmentView);
        }
    }
}