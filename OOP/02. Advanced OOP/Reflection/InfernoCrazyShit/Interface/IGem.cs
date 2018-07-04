using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoCrazyShit.Interface
{
    public interface IGem
    {
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
        string Clarity { get; }
    }
}
