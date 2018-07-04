using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Weapons;

namespace InfernoCrazyShit.Interface
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(string weaponRarity, string weaponType, string name);
    }
}
