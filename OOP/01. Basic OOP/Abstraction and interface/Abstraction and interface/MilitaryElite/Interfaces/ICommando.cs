using System;
using System.Collections.Generic;
using System.Text;


public interface ICommando : ISpecialisedSoldier
{
    List<Missions> missions { get; }
}

