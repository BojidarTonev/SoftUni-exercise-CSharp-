using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Enums;
using InfernoCrazyShit.Interface;
using InfernoCrazyShit.Weapons;

namespace InfernoCrazyShit.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public Weapon CreateWeapon(string weaponRarity, string weaponType, string name)
        {
            WeaponRarity rarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), weaponRarity);

            Type classType = Type.GetType(weaponType);

            Weapon instance = (Weapon)Activator.CreateInstance(classType, new object[] { rarity, name });

            return instance;
        }
    }
}
