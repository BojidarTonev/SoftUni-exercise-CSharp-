using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoCrazyShit.Weapons
{
    public class Knife : Weapon
    {
        public Knife(string rarity, string name) 
            : base(name, 3, 4, rarity, 2)
        {
        }
    }
}
