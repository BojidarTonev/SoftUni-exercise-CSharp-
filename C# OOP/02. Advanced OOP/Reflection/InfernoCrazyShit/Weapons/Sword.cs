using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoCrazyShit.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string rarity, string name)
            : base(name, 4, 6, rarity, 3)
        {
        }
    }
}
