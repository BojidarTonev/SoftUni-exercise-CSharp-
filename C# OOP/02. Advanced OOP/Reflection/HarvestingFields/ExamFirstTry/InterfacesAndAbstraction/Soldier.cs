using System;
using System.Collections.Generic;
using System.Text;

namespace ExamFirstTry.InterfacesAndAbstraction
{
    public abstract class Soldier : ISoldier
    {
        public string name { get; private set; }

        public int age { get; private set; }

        public double experience { get; private set; }

        public double endurance { get; private set; }
    }
}
