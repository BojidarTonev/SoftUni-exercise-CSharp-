using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Interface;

namespace InfernoCrazyShit.Gems
{
    public class AmethystGem : Gem
    {
        public AmethystGem(string clarity)
            : base(clarity, 2, 8, 4)
        {
        }
    }
}
