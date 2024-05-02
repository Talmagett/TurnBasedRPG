using System;
using UnityEngine;

namespace Sample
{
    public class EquipmentEffector : IDisposable
    {
        private readonly Character _character;
        private readonly Equipment _equipment;

        public EquipmentEffector(Character character, Equipment equipment)
        {
            _character = character;
            _equipment = equipment;

            _equipment.OnItemEquipped += AddEffectToCharacter;
            _equipment.OnItemUnequipped += RemoveEffectFromCharacter;
        }

        public void Dispose()
        {
            _equipment.OnItemEquipped -= AddEffectToCharacter;
            _equipment.OnItemUnequipped -= RemoveEffectFromCharacter;
        }

        private void AddEffectToCharacter(Item obj)
        {
            var stats = obj.GetComponents<Stats>();
            if (stats.Length==0)
                return;
            
            foreach (var stat in stats)
            {
                var statValue = _character.GetStat(stat.Name);
                _character.SetStat(stat.Name, statValue + stat.Value);
            }
        }

        private void RemoveEffectFromCharacter(Item obj)
        {
            var stats = obj.GetComponents<Stats>();
            if (stats.Length==0)
                return;

            foreach (var stat in stats)
            {
                var statValue = _character.GetStat(stat.Name);
                _character.SetStat(stat.Name, statValue - stat.Value);
            }
        }
    }
}