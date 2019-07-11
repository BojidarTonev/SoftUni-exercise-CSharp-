using System;
using System.Collections.Generic;
using System.Text;


public class WeaponCreater : IWeaponFactory
{
    public Weapon CreateWeapon(string weaponRarity, string name, string weaponType)
    {
        WeaponEnums rarity = (WeaponEnums)Enum.Parse(typeof(WeaponEnums), weaponRarity);

        Type classType = Type.GetType(weaponType);

        Weapon instance = (Weapon)Activator.CreateInstance(classType, new object[] { name, rarity });

        return instance;
    }
}

