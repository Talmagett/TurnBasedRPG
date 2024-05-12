using System;
using Entities;

namespace Modules.Items.Scripts.Equipment.EquipmentEffector
{
    public class EquipmentEffector : IDisposable
    {
        private readonly IEntity _character;
        private readonly Equipment _equipment;

        public EquipmentEffector(IEntity character, Equipment equipment)
        {
            _character = character;
            _equipment = equipment;

            _equipment.OnItemEquipped += AddEffectToCharacter;
            _equipment.OnItemUnequipped += RemoveEffectFromCharacter;
        }

        public void Dispose()
        {
            // _equipment.OnItemEquipped -= AddEffectToCharacter;
            // _equipment.OnItemUnequipped -= RemoveEffectFromCharacter;
        }

        private void AddEffectToCharacter(ItemModule.Item obj)
        {
            /*var stats = obj.GetComponents<Stats>();
            if (stats.Length==0)
                return;
            
            foreach (var stat in stats)
            {
                var statValue = _character.GetStat(stat.Name);
                _character.SetStat(stat.Name, statValue + stat.Value);
            }*/
        }

        private void RemoveEffectFromCharacter(ItemModule.Item obj)
        {
            /*var stats = obj.GetComponents<Stats>();
            if (stats.Length==0)
                return;

            foreach (var stat in stats)
            {
                var statValue = _character.GetStat(stat.Name);
                _character.SetStat(stat.Name, statValue - stat.Value);
            }*/
        }
    }
}