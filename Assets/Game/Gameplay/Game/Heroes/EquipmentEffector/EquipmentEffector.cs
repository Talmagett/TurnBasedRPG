using System;
using Game.Configs.Configs;
using Game.Configs.Configs.Attributes;
using Game.GameEngine.Entities.Scripts;
using Game.Meta.Inventory.Equipment;
using Game.Meta.Items.Scripts.ItemModule;

namespace Game.Gameplay.Game.Heroes.EquipmentEffector
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

        private void AddEffectToCharacter(Item obj)
        {
            var itemStats = obj.GetComponents<StatAdditive>();
            if (itemStats.Length == 0)
                return;
            var heroStats = _character.Get<SharedCharacterStats>();
            foreach (var stat in itemStats)
            {
                var heroStat = heroStats.GetStat(stat.Stat);
                heroStats.SetStat(stat.Stat, heroStat.Value + stat.Value);
            }
        }

        private void RemoveEffectFromCharacter(Item obj)
        {
            var itemStats = obj.GetComponents<StatAdditive>();
            if (itemStats.Length == 0)
                return;
            var heroStats = _character.Get<SharedCharacterStats>();
            foreach (var stat in itemStats)
            {
                var heroStat = heroStats.GetStat(stat.Stat);
                heroStats.SetStat(stat.Stat, heroStat.Value - stat.Value);
            }
        }
    }
}