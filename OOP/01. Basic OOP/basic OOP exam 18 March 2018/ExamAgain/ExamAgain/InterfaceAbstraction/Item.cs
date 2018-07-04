using System;
using System.Collections.Generic;
using System.Text;

namespace ExamAgain.InterfaceAbstraction
{
    public abstract class Item
    {
        private int weight;

        public Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }

        public virtual void AffectCharacter(Character character)
        {

        }
    }
}
