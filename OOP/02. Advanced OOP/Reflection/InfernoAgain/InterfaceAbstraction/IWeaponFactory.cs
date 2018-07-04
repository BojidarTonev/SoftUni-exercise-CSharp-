using System;
using System.Collections.Generic;
using System.Text;


public interface IWeaponFactory
{
    Weapon CreateWeapon(string weaponRarity, string name, string weaponType);
}

