using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Gems;

namespace InfernoCrazyShit.Interface
{
    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        string Rarity { get; }

        int NumberSlots { get; }

        void AddGem(int socktIndex, Gem gem);

        void RemoveGem(int socketIndex);
    }
}
