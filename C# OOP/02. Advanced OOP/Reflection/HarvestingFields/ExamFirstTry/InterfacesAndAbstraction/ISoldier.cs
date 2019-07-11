using System;
using System.Collections.Generic;
using System.Text;

namespace ExamFirstTry.InterfacesAndAbstraction
{
    public interface ISoldier
    {
        string name { get; }

        int age { get; }

        double experience { get; }

        double endurance { get; }
    }
}
