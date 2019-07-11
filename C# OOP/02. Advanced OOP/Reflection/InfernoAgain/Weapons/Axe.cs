using System;
using System.Collections.Generic;
using System.Text;

public class Axe : Weapon
{
    public Axe(string name, WeaponEnums rarity)
        : base(name, 5, 10, rarity, 4)
    {
    }
}

