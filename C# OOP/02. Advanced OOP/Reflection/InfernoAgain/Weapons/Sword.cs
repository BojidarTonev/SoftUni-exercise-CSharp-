using System;
using System.Collections.Generic;
using System.Text;


public class Sword : Weapon
{
    public Sword(string name, WeaponEnums rarity)
        : base(name, 4, 6, rarity, 3)
    {
    }
}

