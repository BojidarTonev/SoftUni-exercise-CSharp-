using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    int MinDamage { get; }

    int MaxDamage { get; }

    string Name { get; }

    int FinalMinDamage { get; }

    int FinalMaxDamage { get; }

    void AddGem(int socketIndex, Gem gem);

    void RemoveGem(int socketIndex);
}

