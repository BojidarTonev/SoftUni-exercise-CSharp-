using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Weapon : IWeapon, IWeaponRarity
{
    private Gem[] sockets;
    protected Weapon(string name, int minDamage, int maxDamage, WeaponEnums rarity, int gemSlots)
    {
        this.Name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.WeaponRarity = rarity;
        this.sockets = new Gem[gemSlots];
    }

    public int MinDamage { get; }

    public int MaxDamage { get; }

    public string Name { get; }

    public int FinalMinDamage
    {
        get
        {
            return this.MinDamage * (int) WeaponRarity + this.sockets
                       .Where(g => g != null)
                       .Sum(g => g.Strength * 2 + g.Agility);
        }
    }

    public int FinalMaxDamage
    {
        get
        {
            return this.MaxDamage * (int) WeaponRarity + this.sockets
                       .Where(g => g != null)
                       .Sum(g => g.Strength * 3 + g.Agility * 4);
        }
    }

    public WeaponEnums WeaponRarity { get; }

    public void AddGem(int socketIndex, Gem gem)
    {
        if (socketIndex >= 0 && socketIndex < this.sockets.Length)
        {
            sockets[socketIndex] = gem;
        }
    }

    public void RemoveGem(int socketIndex)
    {
        if (socketIndex >= 0 && socketIndex < this.sockets.Length && this.sockets[socketIndex] != null)
        {
            this.sockets[socketIndex] = null;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append(
            $"{this.Name}: {this.FinalMinDamage}-{this.FinalMaxDamage} Damage, +{this.sockets.Where(g => g != null).Sum(g => g.Strength)} Strength, " +
            $"+{this.sockets.Where(g => g != null).Sum(g => g.Agility)} Agility, +{this.sockets.Where(g => g != null).Sum(g => g.Vitality)} Vitality");

        return sb.ToString().TrimEnd();
    }
}

