using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Interface;

namespace InfernoCrazyShit.Gems
{
    public class EmeraldGem : Gem
    {
        public EmeraldGem(string clarity) 
            : base(clarity, 1, 4, 9)
        {
        }
    }
}
