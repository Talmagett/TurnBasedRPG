using Sirenix.Utilities;

namespace Game.Meta.Inventory.Equipment
{
    public class EquipmentPresenter
    {
        private readonly Equipment _equipment;
        private readonly EquipmentView _equipmentView;

        public EquipmentPresenter(Equipment equipment, EquipmentView equipmentView)
        {
            _equipment = equipment;
            _equipmentView = equipmentView;

            _equipment.GetItems().ForEach(t => _equipmentView.SetIcon(t.Key, t.Value.Icon));
        }
    }
}