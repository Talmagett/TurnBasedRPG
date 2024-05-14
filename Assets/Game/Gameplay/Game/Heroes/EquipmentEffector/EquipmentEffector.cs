using System;
using Configs;
using Configs.Attributes;
using Modules.Entities.Scripts;
using Modules.Items.Scripts.Equipment;

namespace Game.Heroes.EquipmentEffector
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
            _equipment.OnItemEquipped -= AddEffectToCharacter;
            _equipment.OnItemUnequipped -= RemoveEffectFromCharacter;
        }

        private void AddEffectToCharacter(Modules.Items.Scripts.ItemModule.Item obj)
        {
            var itemStats = obj.GetComponents<StatAdditive>();
            if (itemStats.Length==0)
                return;
            var heroStats = _character.Get<SharedCharacterStats>();
            foreach (var stat in itemStats)
            {
                var heroStat = heroStats.GetStat(stat.Stat);
                heroStats.SetStat(stat.Stat,heroStat.Value+stat.Value);
            }
        }

        private void RemoveEffectFromCharacter(Modules.Items.Scripts.ItemModule.Item obj)
        {
            var itemStats = obj.GetComponents<StatAdditive>();
            if (itemStats.Length==0)
                return;
            var heroStats = _character.Get<SharedCharacterStats>();
            foreach (var stat in itemStats)
            {
                var heroStat = heroStats.GetStat(stat.Stat);
                heroStats.SetStat(stat.Stat,heroStat.Value-stat.Value);
            }
        }
    }
}