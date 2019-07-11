using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Enums;
using InfernoCrazyShit.Gems;
using InfernoCrazyShit.Interface;

namespace InfernoCrazyShit.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private Gem[] gems;
        protected Weapon(string name, int minDamage, int maxDamage, string rarity, int numberSlots)
        {
            this.Name = name;
            this.MaxDamage = maxDamage;
            this.MinDamage = minDamage;
            this.NumberSlots = numberSlots;
            this.gems = new Gem[numberSlots];
            InitializeValues(rarity);
        }

        private void InitializeValues(string rarity)
        {
            int weaponBonus = (int)Enum.Parse(typeof(WeaponRarity), rarity);

            this.MinDamage *= weaponBonus;
            this.MaxDamage *= weaponBonus;
        }

        public string Name { get; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public string Rarity { get; }

        public int NumberSlots { get; }

        public void AddGem(int socketIndex, Gem gem)
        {
            if (socketIndex >= 0 && socketIndex < this.gems.Length)
            {
                this.gems[socketIndex] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index < this.gems.Length && index >= 0 && gems[index] != null)
            {
                gems[index] = null;
            }
        }
    }
}
