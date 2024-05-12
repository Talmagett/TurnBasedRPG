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
        
        private HeroParty _heroParty;

        private int _index=0;
        
        [Inject]
        public void Ctor(HeroParty heroParty)
        {
            _heroParty = heroParty;
        }

        [Button]
        public void SetCharacterIndex(int index = 0)
        {
            _index = index;
        }

        public void Show()
        {
            equipmentView.gameObject.SetActive(true);
            var equipmentPresenter = new EquipmentPresenter(_heroParty.HeroDataArray[_index].Equipment,equipmentView);
        }

        public void Hide()
        {
            equipmentView.gameObject.SetActive(false);
        }
    }
}