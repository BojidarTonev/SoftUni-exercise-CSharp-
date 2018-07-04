using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoCrazyShit.Weapons
{
    public class Axe : Weapon
    {
        public Axe(string rarity, string name) 
            : base(name, 5, 10, rarity, 4)
        {
        }
    }
}
