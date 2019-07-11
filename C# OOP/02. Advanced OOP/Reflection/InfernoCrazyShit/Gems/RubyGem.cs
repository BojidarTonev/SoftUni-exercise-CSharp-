using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Interface;

namespace InfernoCrazyShit.Gems
{
    public class RubyGem : Gem
    {
        public RubyGem(string clarity) 
            : base(clarity, 7, 2, 5)
        {
        }
    }
}
