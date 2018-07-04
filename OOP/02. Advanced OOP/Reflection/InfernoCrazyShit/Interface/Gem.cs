using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Interface;

namespace InfernoCrazyShit.Gems
{
    public abstract class Gem : IGem
    {
        public Gem(string clarity, int strength, int agility, int vitality)
        {
            this.Clarity = clarity;
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            InitiazleBonus(clarity);
        }

        private void InitiazleBonus(string clarity)
        {
            int gemClarity = (int)Enum.Parse(typeof(GemClarity), clarity);
            this.Agility *= gemClarity;
            this.Strength *= gemClarity;
            this.Vitality *= gemClarity;
        }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public string Clarity { get; }
    }
}
