using System;
using System.Collections.Generic;
using System.Text;



public class Knife : Weapon
{
    public Knife(string name, WeaponEnums rarity)
        : base(name, 3, 4, rarity, 2)
    {
    }
}

